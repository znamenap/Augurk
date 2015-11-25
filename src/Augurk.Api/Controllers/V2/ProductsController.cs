﻿using Augurk.Api.Managers;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;

namespace Augurk.Api.Controllers.V2
{
    /// <summary>
    /// ApiController for retrieving the available products.
    /// </summary>
    [RoutePrefix("api/v2/products")]
    public class ProductsController : ApiController
    {
        private readonly ProductManager _productsManager = new ProductManager();

        /// <summary>
        /// Gets all available products.
        /// </summary>
        /// <returns>A range of product names.</returns>
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetProducts()
        {
            return await _productsManager.GetProductsAsync();
        }

        /// <summary>
        /// Deletes the provided product
        /// </summary>
        /// <returns>A range of product names.</returns>
        [Route("{product}")]
        [HttpDelete]
        public async Task DeleteProducts(string product)
        {
            await _productsManager.DeleteProductAsync(product);
        }

        /// <summary>
        /// Deletes the provided product
        /// </summary>
        /// <returns>A range of product names.</returns>
        [Route("{product}/versions/{version}")]
        [HttpDelete]
        public async Task DeleteProducts(string product, string version)
        {
            await _productsManager.DeleteProductAsync(product, version);
        }

        /// <summary>
        /// Gets the tags placed on features contained within the specified <paramref name="productName">product</paramref>.
        /// </summary>
        /// <param name="productName">Name of the product to get the tags for.</param>
        /// <returns>Returns a range of tags.</returns>
        [Route("{productName}/tags")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetTags(string productName)
        {
            return await _productsManager.GetTagsAsync(productName);
        }
    }
}
