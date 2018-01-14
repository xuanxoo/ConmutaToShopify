using CrvnetSync.Entities;
using CrvnetSync.Models;
using CrvnetSync.Repositories;
using ShopifySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CrvnetSync.Code;
using System.IO;

namespace CrvnetSync.Services
{
    public class ShopifyService
    {
        private EntradaStrockRepository entradaRepo;
        private ReferenciaRepository referenciaRepo;
        private ProductService productShopifyService;

        private const string shopifyCode = "crvnetsync";
        private const string shopifyUrl = "https://desgonztruck.myshopify.com";
        private const string shopifyKey = "0876792a84855bd4a4d7cfdabd767eac";
        private const string shopifySecretKey = "4072e7901948ac219a3f1c62fee2062c";

        private string ImgPath = ConfigurationManager.AppSettings["ImgPath"];

        public ShopifyService()
        {

            this.entradaRepo = new Repositories.EntradaStrockRepository();
            this.referenciaRepo = new ReferenciaRepository();
        }

        public void InsertarEntradas()
        {
            var productos = new List<Producto>();

            var entradas = entradaRepo.Almacenadas();
            foreach (var entrada in entradas)
            {
                var imagenes = entradaRepo.ImagenesPieza(entrada.refid);
                productos.Add(new Producto(entrada, imagenes));
            }

            Task theTask = ProcessAsync(productos);
            theTask.Wait();
        }

        public async Task ProcessAsync(IEnumerable<Producto> productos)
        {

            foreach (var p in productos) { 
                try
                {
                    Console.WriteLine("Importando producto: " p.referencia);
                    await AddShopifyProduct(p);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }

        public async Task<Product> AddShopifyProduct(Producto productoShopify)
        {
            Product product = RellenaProductoShopify(productoShopify);

            var service = new ProductService(shopifyUrl, "aa59f8ba8ff9ed4b88ac2344b670ef04");
            //By default, creating a product will publish it. To create an unpublished product:+1:
            return await service.CreateAsync(product, new ProductCreateOptions() { Published = true });
        }

        private Product RellenaProductoShopify(Producto productoShopify)
        {
            var pVarians = new ProductVariant();

            if (productoShopify.precio > 0)
                pVarians.Price = productoShopify.precio;

            var pImages = new List<ProductImage>();

            if(productoShopify.imagenesPath.Count() > 0)
            {
                foreach(var imgName in productoShopify.imagenesPath)
                {
                    //var imgPath = Path.Combine(ImgPath, imgName);
                    var imgPath = ImgPath + "01\\01.jpg";
                    var imgBase64 = Utils.ImageToBase64(imgPath);

                    var imgShpifi = new ProductImage
                    {
                        ProductId = productoShopify.id,
                        Filename = productoShopify.titulo.Replace(' ', '_'),
                        Attachment = imgBase64
                    };
                    pImages.Add(imgShpifi);
                }
            }

            var product = new Product()
            {
                Id = productoShopify.id,
                Title = productoShopify.titulo,
                Vendor = productoShopify.marca,
                BodyHtml = productoShopify.descripcion,
                ProductType = productoShopify.familia,
                Variants = new List<ProductVariant>() { pVarians },
                Tags = productoShopify.marca + "," + productoShopify.modelo + "," + productoShopify.version,
                Images = pImages
            };

            return product;
        }
    }
}
