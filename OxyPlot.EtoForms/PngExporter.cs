﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PngExporter.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Provides functionality to export plots to png.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot.EtoForms
{
    using Eto.Drawing;
    //using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Provides functionality to export plots to png.
    /// </summary>
    public class PngExporter : IExporter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PngExporter" /> class.
        /// </summary>
        public PngExporter()
        {
            this.Width = 700;
            this.Height = 400;
            this.Resolution = 96;
            this.Background = OxyColors.White;
        }

        /// <summary>
        /// Gets or sets the width of the output image.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the output image.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the resolution (dpi) of the output image.
        /// </summary>
        public double Resolution { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public OxyColor Background { get; set; }

        /// <summary>
        /// Exports the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="background">The background.</param>
        /// <param name="resolution">The resolution.</param>
        public static void Export(IPlotModel model, string fileName, int width, int height, OxyColor background, double resolution = 96)
        {
            var exporter = new PngExporter { Width = width, Height = height, Background = background, Resolution = resolution };
            using (var stream = File.Create(fileName))
            {
                exporter.Export(model, stream);
            }
        }

        /// <summary>
        /// Exports the specified <see cref="PlotModel" /> to the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="stream">The output stream.</param>
        public void Export(IPlotModel model, Stream stream)
        {
            using (var bm = this.ExportToBitmap(model))
            {
                bm.Save(stream, ImageFormat.Png);
            }
        }
        
        /// <summary>
        /// Exports the specified <see cref="PlotModel" /> to a <see cref="Bitmap" />.
        /// </summary>
        /// <param name="model">The model to export.</param>
        /// <returns>A bitmap.</returns>
        public Bitmap ExportToBitmap(IPlotModel model)
        {
            var bm = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgba);
            using (var g = new Graphics(bm))
            {
				if (this.Background.IsVisible())
				{
					g.FillRectangle(this.Background.ToEto(), 0, 0, this.Width, this.Height);
				}

                using (var rc = new GraphicsRenderContext(g) { RendersToScreen = false })
                {
                    model.Update(true);
                    model.Render(rc, this.Width, this.Height);
                }

				return bm;
            }
        }
    }
}
