﻿// ****************************************************************************
// <copyright file="ShellToastService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellToastService"/>.
    /// </summary>
    public class ShellToastService : IShellToastService
    {
        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        public void Show(string title, string content)
        {
            Show(title, content, null);
        }

        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        /// <param name="navigationUri">Uri to navigate to if the user taps the toast message.</param>
        public void Show(string title, string content, Uri navigationUri)
        {
            var toast = new ShellToast()
            {
                Title = title,
                Content = content,
                NavigationUri = navigationUri
            };

            toast.Show();
        }
    }
}