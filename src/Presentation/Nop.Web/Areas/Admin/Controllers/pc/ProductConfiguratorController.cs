using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class ProductConfiguratorController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly IProductConfiguratorModelFactory _productConfiguratorModelFactory;
        private readonly IProductConfiguratorService _productConfiguratorService;
        private readonly IProductConfiguratorPluginManager _productConfiguratorPluginManager;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public ProductConfiguratorController(
            ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            IProductConfiguratorModelFactory productConfiguratorModelFactory,
            IProductConfiguratorService productConfiguratorService,
            IProductConfiguratorPluginManager productConfiguratorPluginManager,
            INotificationService notificationService,
            IPermissionService permissionService,
            IPictureService pictureService,
            IProductService productService,
            IWorkContext workContext)
        {
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _productConfiguratorModelFactory = productConfiguratorModelFactory;
            _productConfiguratorService = productConfiguratorService;
            _productConfiguratorPluginManager = productConfiguratorPluginManager;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _productService = productService;
            _workContext = workContext;
        }

        #endregion

        #region Utilities

        protected virtual async Task UpdateLocalesAsync(ProductConfigurator productConfigurator, ProductConfiguratorModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.ShortDescription,
                    localized.ShortDescription,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.FullDescription,
                    localized.FullDescription,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.MetaKeywords,
                    localized.MetaKeywords,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.MetaDescription,
                    localized.MetaDescription,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(productConfigurator,
                    x => x.MetaTitle,
                    localized.MetaTitle,
                    localized.LanguageId);
            }
        }

        #endregion

        #region List

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //prepare model
            var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorSearchModelAsync(new ProductConfiguratorSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(ProductConfiguratorSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorListModelAsync(searchModel);

            return Json(model);
        }

        #endregion

        #region Create / Edit / Delete

        public virtual async Task<IActionResult> Create()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //prepare model
            var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorModelAsync(new ProductConfiguratorModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Create(ProductConfiguratorModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var productConfigurator = model.ToEntity<ProductConfigurator>();
                await _productConfiguratorService.InsertProductConfiguratorAsync(productConfigurator);

                //locales
                await UpdateLocalesAsync(productConfigurator, model);

                await _productConfiguratorService.UpdateProductConfiguratorAsync(productConfigurator);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewProductConfigurator",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewProductConfigurator"), productConfigurator.Name), productConfigurator);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.ProductConfigurators.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");
                
                return RedirectToAction("Edit", new { id = productConfigurator.Id });
            }

            //prepare model
            model = await _productConfiguratorModelFactory.PrepareProductConfiguratorModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //try to get a ProductConfigurator with the specified id
            var productConfigurator = await _productConfiguratorService.GetProductConfiguratorByIdAsync(id);
            if (productConfigurator == null || productConfigurator.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorModelAsync(null, productConfigurator);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Edit(ProductConfiguratorModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //try to get a ProductConfigurator with the specified id
            var productConfigurator = await _productConfiguratorService.GetProductConfiguratorByIdAsync(model.Id);
            if (productConfigurator == null || productConfigurator.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                
                productConfigurator = model.ToEntity(productConfigurator);
                
                await _productConfiguratorService.UpdateProductConfiguratorAsync(productConfigurator);

                //locales
                await UpdateLocalesAsync(productConfigurator, model);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditProductConfigurator",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditProductConfigurator"), productConfigurator.Name), productConfigurator);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.ProductConfigurators.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");
                
                return RedirectToAction("Edit", new { id = productConfigurator.Id });
            }

            //prepare model
            model = await _productConfiguratorModelFactory.PrepareProductConfiguratorModelAsync(model, productConfigurator, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //try to get a ProductConfigurator with the specified id
            var productConfigurator = await _productConfiguratorService.GetProductConfiguratorByIdAsync(id);
            if (productConfigurator == null)
                return RedirectToAction("List");

            await _productConfiguratorService.DeleteProductConfiguratorAsync(productConfigurator);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteProductConfigurator",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteProductConfigurator"), productConfigurator.Name), productConfigurator);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.ProductConfigurators.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            if (selectedIds != null)
            {
                var productConfigurators = await _productConfiguratorService.GetProductConfiguratorsByIdsAsync(selectedIds.ToArray());
                await _productConfiguratorService.DeleteProductConfiguratorsAsync(productConfigurators);

                var locale = await _localizationService.GetResourceAsync("ActivityLog.DeleteProductConfigurator");
                foreach (var productConfigurator in productConfigurators)
                {
                    //activity log
                    await _customerActivityService.InsertActivityAsync("DeleteProductConfigurator", string.Format(locale, productConfigurator.Name), productConfigurator);
                }
            }

            return Json(new { Result = true });
        }

        #endregion

        #region Export / Import

        public virtual async Task<IActionResult> ExportXml()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            try
            {
                var productConfigurators = await _productConfiguratorService.GetAllProductConfiguratorsAsync();
                var xml = await _exportManager.ExportProductConfiguratorsToXmlAsync(productConfigurators);
                return File(Encoding.UTF8.GetBytes(xml), "application/xml", "ProductConfigurators.xml");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        public virtual async Task<IActionResult> ExportXlsx()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            try
            {
                var bytes = await _exportManager.ExportProductConfiguratorsToXlsxAsync((await _productConfiguratorService.GetAllProductConfiguratorsAsync()).Where(p => !p.Deleted));

                return File(bytes, MimeTypes.TextXlsx, "ProductConfigurators.xlsx");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> ImportFromXlsx(IFormFile importexcelfile)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //a vendor cannot import ProductConfigurators
            if (await _workContext.GetCurrentVendorAsync() != null)
                return AccessDeniedView();

            try
            {
                if (importexcelfile != null && importexcelfile.Length > 0)
                {
                    await _importManager.ImportProductConfiguratorsFromXlsxAsync(importexcelfile.OpenReadStream());
                }
                else
                {
                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
                    return RedirectToAction("List");
                }

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.ProductConfigurators.Imported"));
                return RedirectToAction("List");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        #endregion

        #region Products

        //[HttpPost]
        //public virtual async Task<IActionResult> ProductList(ProductConfiguratorProductSearchModel searchModel)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return await AccessDeniedDataTablesJson();

        //    //try to get a ProductConfigurator with the specified id
        //    var productConfigurator = await _productConfiguratorService.GetProductConfiguratorByIdAsync(searchModel.ProductConfiguratorId)
        //        ?? throw new ArgumentException("No ProductConfigurator found with the specified id");

        //    //prepare model
        //    var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorProductListModelAsync(searchModel, productConfigurator);

        //    return Json(model);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> ProductUpdate(ProductConfiguratorProductModel model)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return AccessDeniedView();

        //    //try to get a product ProductConfigurator with the specified id
        //    var productProductConfigurator = await _productConfiguratorService.GetProductProductConfiguratorByIdAsync(model.Id)
        //        ?? throw new ArgumentException("No product ProductConfigurator mapping found with the specified id");

        //    //fill entity from model
        //    productProductConfigurator = model.ToEntity(productProductConfigurator);
        //    await _productConfiguratorService.UpdateProductProductConfiguratorAsync(productProductConfigurator);

        //    return new NullJsonResult();
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> ProductDelete(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return AccessDeniedView();

        //    //try to get a product ProductConfigurator with the specified id
        //    var productProductConfigurator = await _productConfiguratorService.GetProductProductConfiguratorByIdAsync(id)
        //        ?? throw new ArgumentException("No product ProductConfigurator mapping found with the specified id");

        //    await _productConfiguratorService.DeleteProductProductConfiguratorAsync(productProductConfigurator);

        //    return new NullJsonResult();
        //}

        //public virtual async Task<IActionResult> ProductAddPopup(int productConfiguratorId)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return AccessDeniedView();

        //    //prepare model
        //    var model = await _productConfiguratorModelFactory.PrepareAddProductToProductConfiguratorSearchModelAsync(new AddProductToProductConfiguratorSearchModel());

        //    return View(model);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> ProductAddPopupList(AddProductToProductConfiguratorSearchModel searchModel)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return await AccessDeniedDataTablesJson();

        //    //prepare model
        //    var model = await _productConfiguratorModelFactory.PrepareAddProductToProductConfiguratorListModelAsync(searchModel);

        //    return Json(model);
        //}

        //[HttpPost]
        //[FormValueRequired("save")]
        //public virtual async Task<IActionResult> ProductAddPopup(AddProductToProductConfiguratorModel model)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
        //        return AccessDeniedView();

        //    //get selected products
        //    var selectedProducts = await _productService.GetProductsByIdsAsync(model.SelectedProductIds.ToArray());
        //    if (selectedProducts.Any())
        //    {
        //        var existingProductProductConfigurators = await _productConfiguratorService
        //            .GetProductProductConfiguratorsByProductConfiguratorIdAsync(model.ProductConfiguratorId, showHidden: true);
        //        foreach (var product in selectedProducts)
        //        {
        //            //whether product ProductConfigurator with such parameters already exists
        //            if (_productConfiguratorService.FindProductProductConfigurator(existingProductProductConfigurators, product.Id, model.ProductConfiguratorId) != null)
        //                continue;

        //            // PCFG TODO
        //            throw new NotImplementedException("ProductAddPopup is not correctly updated");

        //            //insert the new product ProductConfigurator mapping
        //            await _productConfiguratorService.InsertProductProductConfiguratorAsync(new Product
        //            {
        //                //ProductConfiguratorId = model.ProductConfiguratorId,
        //                //ProductId = product.Id,
        //                //IsFeaturedProduct = false,
        //                DisplayOrder = 1
        //            });
        //        }
        //    }

        //    ViewBag.RefreshPage = true;

        //    return View(new AddProductToProductConfiguratorSearchModel());
        //}

        #endregion

        #region Configuration

        public virtual async Task<IActionResult> Configuration(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //prepare model
            var model = await _productConfiguratorModelFactory.PrepareProductConfiguratorConfigurationModelAsync(
                new ProductConfiguratorConfigurationModel
                {
                    ConfiguratorId = id,
                    Initial = true
                });

            await LoadConfiguratorPlugin(model);

            return View(model);
        }

        private async Task LoadConfiguratorPlugin(ProductConfiguratorConfigurationModel model)
        {
            var productConfigurator = await _productConfiguratorPluginManager
                .GetProductConfiguratorProvider(model.ConfiguratorId);
            if (productConfigurator == null)
            {
                model.ViewName = "Message";
                model.DefaultModel = new ProductConfiguratorMessageModel();
                model.ModelType = typeof(ProductConfiguratorMessageModel);
            }
            else
            {
                model.ViewName = productConfigurator.GetViewName();
                model.DefaultModel = productConfigurator.GetDefaultModel();
                model.ModelType = productConfigurator.GetModelType();
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Configuration(ProductConfiguratorConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProductConfigurators))
                return AccessDeniedView();

            //prepare model
            model = await _productConfiguratorModelFactory.PrepareProductConfiguratorConfigurationModelAsync(model);

            await LoadConfiguratorPlugin(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(ProductConfiguratorCalculationModel model)
        {
            var productConfigurator = await _productConfiguratorPluginManager.GetProductConfiguratorProvider(model.ConfiguratorId);
            if (productConfigurator != null)
            {
                string json;
                decimal price;
                string description;
                bool isValid;

                (json, description, price, isValid) = productConfigurator.CalculateToJson(model.Json);

                model.Json = json;
                model.Description = description;
                model.IsValid = isValid;
                model.Price = price.ToString();
                model.Tax = "btw";
                model.SubTotal = "sub total";
            }
            return Json(model);
        }

        #endregion
    }
}