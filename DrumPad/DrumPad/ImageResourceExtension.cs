//
// ImageResourceExtension.cs
//
// Author:
//       Mark Smith <mark.smith@xamarin.com>
//
// Copyright (c) 2016 Xamarin, Microsoft.


using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace XamarinUniversity.Infrastructure
{
    
    /// <summary>
    /// XAML markup extension to load an image from embedded resources.
    /// </summary>
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension<ImageSource>
    {
        /// <summary>
        /// Optional System.Type used to identify the assembly where
        /// the resources are located
        /// </summary>
        /// <value>The type of the assembly resolver.</value>
        public Type AssemblyResolverType { get; set; }

        /// <summary>
        /// Resource ID which identifies the image
        /// </summary>
        /// <value>The source.</value>

        public string Source { get; set; }
        /// <summary>
        /// Returns the image
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="serviceProvider">Service provider.</param>

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
        }

        /// <summary>
        /// Returns the image
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="serviceProvider">Service provider.</param>
        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            Assembly assembly = null;

            if (AssemblyResolverType != null)
            {
                assembly = AssemblyResolverType.GetTypeInfo().Assembly;
            }
            else
            {
                var app = Application.Current;

                if (app != null)
                {
                    assembly = app.GetType().GetTypeInfo().Assembly;
                }
            }

            return Source == null ? null : ImageSource.FromResource(Source, assembly);
        }
    }
    
}