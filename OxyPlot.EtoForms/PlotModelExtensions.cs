// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlotModelExtensions.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Provides extension methods to the <see cref="PlotModel" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot.EtoForms
{
    using System;
    using Eto.Drawing;

    /// <summary>
    /// Provides extension methods to the <see cref="PlotModel" />.
    /// </summary>
    public static class PlotModelExtensions
    {
        /// <summary>
        /// Creates an SVG string.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="width">The width (points).</param>
        /// <param name="height">The height (points).</param>
        /// <param name="isDocument">if set to <c>true</c>, the xml headers will be included (?xml and !DOCTYPE).</param>
        /// <returns>A <see cref="string" />.</returns>
        public static string ToSvg(this PlotModel model, double width, double height, bool isDocument)
        {
			/* TODO Why is this needed at all? */
			using (var g = new Graphics(new Bitmap(1, 1, PixelFormat.Format32bppRgba)))
			{
				using (var rc = new GraphicsRenderContext(g) { RendersToScreen = false })
				{
					return OxyPlot.SvgExporter.ExportToString(model, width, height, isDocument, rc);
				}
			}
        }
    }
}