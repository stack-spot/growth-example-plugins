package {{global_computed_inputs.base_package}}.samplefeign.feign;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.RequestMapping;

import {{global_computed_inputs.base_package}}.samplefeign.dto.Product;
import {{global_computed_inputs.base_package}}.samplefeign.dto.ProductList;

import org.springframework.web.bind.annotation.PathVariable;

import static org.springframework.web.bind.annotation.RequestMethod.GET;

@FeignClient(
    value = "${sample.feign.name}",
    url = "${sample.feign.url}"
)
public interface ISampleFeignClient {

  @RequestMapping(method = GET, value = "/products")
  ProductList fetchProductList();

  @RequestMapping(method = GET, value = "/products/{productId}")
  Product fetchProduct(@PathVariable("productId") Integer productId);
}
