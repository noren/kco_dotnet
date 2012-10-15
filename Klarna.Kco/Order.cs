﻿#region Copyright Header
// ----------------------------------------------------------------------------
// <copyright file="Order.cs" company="Klarna AB">
//     Copyright 2012 Klarna AB
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//         http://www.apache.org/licenses/LICENSE-2.0
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.
// </copyright>
// <author>Klarna Support: support@klarna.com</author>
// <link>http://integration.klarna.com/</link>
// ----------------------------------------------------------------------------
#endregion
namespace Klarna.Checkout
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The order resource.
    /// </summary>
    public class Order : IResource
    {
        #region Private Fields

        /// <summary>
        /// The data.
        /// </summary>
        private Dictionary<string, object> resourceData;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            resourceData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="data">
        /// Initial data.
        /// </param>
        public Order(Dictionary<string, object> data)
        {
            resourceData = data;
        }

        #endregion

        #region Implementation of IResource

        /// <summary>
        /// Gets or sets the URL of the resource.
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// Gets the content type of the resource.
        /// </summary>
        public string ContentType
        {
            get { return "application/vnd.klarna.checkout.aggregated-order-v1+json"; }
        }

        /// <summary>
        /// Replace resource with the new data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Parse(Dictionary<string, object> data)
        {
            resourceData = data;
        }

        /// <summary>
        /// Basic representation of the resource.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public Dictionary<string, object> Marshal()
        {
            return resourceData;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the value of a key.
        /// The key is added if it doesn't exist.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// key is null
        /// </exception>
        public void SetValue(string key, object value)
        {
            if (resourceData.ContainsKey(key))
            {
                resourceData[key] = value;
            }
            else
            {
                resourceData.Add(key, value);
            }
        }

        /// <summary>
        /// Gets the value of a key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// key is null.
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// key does not exist.
        /// </exception>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetValue(string key)
        {
            return resourceData[key];
        }

        #endregion
    }
}