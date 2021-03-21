using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Nop.Web.Framework.Components
{
    /// <summary>
    /// An <see cref="IViewComponentResult"/> which writes text when executed.
    /// </summary>
    /// <remarks>
    /// The provided content will be raw when written. To write encoded content, use an
    /// <see cref="ContentViewComponentResult"/>.
    /// </remarks>
    public class RawViewComponentResult : IViewComponentResult
    {
        /// <summary>
        /// Initializes a new <see cref="RawViewComponentResult"/>.
        /// </summary>
        /// <param name="content">Content to write.</param>
        public RawViewComponentResult(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Encodes and writes the <see cref="Content"/>.
        /// </summary>
        /// <param name="context">The <see cref="ViewComponentContext"/>.</param>
        public void Execute(ViewComponentContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Writer.Write(Content);
        }

        /// <summary>
        /// Encodes and writes the <see cref="Content"/>.
        /// </summary>
        /// <param name="context">The <see cref="ViewComponentContext"/>.</param>
        /// <returns>A completed <see cref="Task"/>.</returns>
        public Task ExecuteAsync(ViewComponentContext context)
        {
            Execute(context);

            return Task.CompletedTask;
        }
    }
}