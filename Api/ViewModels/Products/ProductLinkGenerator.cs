namespace Api.ViewModels.Products
{
    public static class ProductLinkGenerator
    {
        private static string ProductUrl = "https://localhost:7195/ProductController";
        public static ProductVm AddLinks(this ProductVm viewModel)
        {
            var links = new List<LinkDto>()
            {
               new LinkDto (ProductUrl , "update_product" ,HttpMethod.Put.Method) ,
               new LinkDto ($"{ProductUrl}/{viewModel.Id}","delete_product" , HttpMethod.Delete.Method),
            };
            viewModel.Links.AddRange(links);
            return viewModel;
        }

        public static List<ProductVm> AddLinks(this List<ProductVm> viewModel)
        {
            if (viewModel == null)
                return null;

            viewModel.ForEach(item =>
            {
                var links = new List<LinkDto>()
                {
                   new LinkDto (ProductUrl , "update_product" ,HttpMethod.Put.Method) ,
                   new LinkDto ($"{ProductUrl}/{item.Id}","delete_product" , HttpMethod.Delete.Method),
                   new LinkDto ($"{ProductUrl}/{item.Id}","self" , HttpMethod.Get.Method),
                };
                item.Links.AddRange(links);
            });
            return viewModel;
        }
    } 
}
