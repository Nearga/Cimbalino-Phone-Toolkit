﻿// ****************************************************************************
// <copyright file="MarketplaceAppEntryNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-07-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Xml;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents the contents of the application entry information from the marketplace.
    /// </summary>
    public class MarketplaceAppEntryNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application entry .
        /// </summary>
        /// <value>The application entry .</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the application entry title.
        /// </summary>
        /// <value>The application entry title.</value>
        public MarketplaceAppContentNode Title { get; set; }

        /// <summary>
        /// Gets or sets the application entry identifier.
        /// </summary>
        /// <value>The application entry identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application entry version.
        /// </summary>
        /// <value>The application entry version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the application entry payload identifier.
        /// </summary>
        /// <value>The application entry payload identifier.</value>
        public string PayloadId { get; set; }

        /// <summary>
        /// Gets or sets the application entry sku identifier.
        /// </summary>
        /// <value>The application entry sku identifier.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the application entry sku last updated.
        /// </summary>
        /// <value>The application entry sku last updated.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public DateTime? SkuLastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application entry is available in the country.
        /// </summary>
        /// <value>true if the application entry is available in the country; otherwise, false.</value>
        public bool? IsAvailableInCountry { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application entry is available in the store.
        /// </summary>
        /// <value>true if the application entry is available in the store; otherwise, false.</value>
        public bool? IsAvailableInStore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application entry is compatible with the client type.
        /// </summary>
        /// <value>true if the application entry is compatible with the client type; otherwise, false.</value>
        public bool? IsClientTypeCompatible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application entry is compatible with the hardware.
        /// </summary>
        /// <value>true if the application entry is compatible with the hardware; otherwise, false.</value>
        public bool? IsHardwareCompatible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application entry is blacklisted.
        /// </summary>
        /// <value>true if the application entry is blacklisted; otherwise, false.</value>
        public bool? IsBlacklisted { get; set; }

        /// <summary>
        /// Gets or sets the application entry url.
        /// </summary>
        /// <value>The application entry url.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the application entry package size.
        /// </summary>
        /// <value>The application entry package size.</value>
        public int? PackageSize { get; set; }

        /// <summary>
        /// Gets or sets the application entry install size.
        /// </summary>
        /// <value>The application entry install size.</value>
        public int? InstallSize { get; set; }

        /// <summary>
        /// Gets or sets the application entry client types.
        /// </summary>
        /// <value>The application entry client types.</value>
        public string[] ClientTypes { get; set; }

        /// <summary>
        /// Gets or sets the application entry supported languages.
        /// </summary>
        /// <value>The application entry supported languages.</value>
        public string[] SupportedLanguages { get; set; }

        /// <summary>
        /// Gets or sets the application entry device capabilities.
        /// </summary>
        /// <value>The application entry device capabilities.</value>
        public MarketplaceAppCapabilitiesNode DeviceCapabilities { get; set; }

        #endregion

        internal static MarketplaceAppEntryNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppEntryNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "a:updated":
                        node.Updated = reader.ReadElementContentAsDateTime();
                        break;

                    case "a:title":
                        node.Title = MarketplaceAppContentNode.ParseXml(reader);
                        break;

                    case "a:id":
                        node.Id = reader.ReadElementContentAsUrn();
                        break;

                    case "version":
                        node.Version = reader.ReadElementContentAsString();
                        break;

                    case "payloadId":
                        node.PayloadId = reader.ReadElementContentAsUrn();
                        break;

                    case "skuId":
                        node.SkuId = reader.ReadElementContentAsUrn();
                        break;

                    case "skuLastUpdated":
                        node.SkuLastUpdated = reader.ReadElementContentAsDateTime();
                        break;

                    case "isAvailableInCountry":
                        node.IsAvailableInCountry = reader.ReadElementContentAsBoolean();
                        break;

                    case "isAvailableInStore":
                        node.IsAvailableInStore = reader.ReadElementContentAsBoolean();
                        break;

                    case "isClientTypeCompatible":
                        node.IsClientTypeCompatible = reader.ReadElementContentAsBoolean();
                        break;

                    case "isHardwareCompatible":
                        node.IsHardwareCompatible = reader.ReadElementContentAsBoolean();
                        break;

                    case "isBlacklisted":
                        node.IsBlacklisted = reader.ReadElementContentAsBoolean();
                        break;

                    case "url":
                        node.Url = reader.ReadElementContentAsString();
                        break;

                    case "packageSize":
                        node.PackageSize = reader.ReadElementContentAsInt();
                        break;

                    case "installSize":
                        node.InstallSize = reader.ReadElementContentAsInt();
                        break;

                    case "clientTypes":
                        node.ClientTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "supportedLanguages":
                        node.SupportedLanguages = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "deviceCapabilities":
                        var deviceCapabilitiesString = reader.ReadElementContentAsString();

                        if (!string.IsNullOrEmpty(deviceCapabilitiesString))
                        {
                            deviceCapabilitiesString = string.Format("<root>{0}</root>", HttpUtility.HtmlDecode(deviceCapabilitiesString));

                            using (var stringReader = new StringReader(deviceCapabilitiesString))
                            {
                                using (var reader2 = XmlReader.Create(stringReader))
                                {
                                    reader2.ReadStartElement();

                                    node.DeviceCapabilities = MarketplaceAppCapabilitiesNode.ParseXml(reader2);

                                    reader2.ReadEndElement();
                                }
                            }
                        }
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.ReadEndElement();

            return node;
        }
    }
}