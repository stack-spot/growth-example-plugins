package {{global_computed_inputs.base_package}}.samplefeign.controller;

import {{global_computed_inputs.base_package}}.samplefeign.feign.ISampleFeignClient;
import {{global_computed_inputs.base_package}}.samplefeign.dto.Product;
import {{global_computed_inputs.base_package}}.samplefeign.dto.ProductList;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

import static org.springframework.http.HttpStatus.OK;

@RestController
@RequestMapping("/sample-feign/product")
public class SampleFeignController {

  private final ISampleFeignClient feignClient;

  @Autowired
  private SampleFeignController(ISampleFeignClient feignClient) {
    this.feignClient = feignClient;
  }

  @GetMapping("/list")
  @ResponseStatus(OK)
  public ProductList fetchProductList() {
    return feignClient.fetchProductList();
  }

  @GetMapping("/{productId}")
  @ResponseStatus(OK)
  public Product fetchProductById(
      @PathVariable("productId") Integer productId
  ) {
    return feignClient.fetchProduct(productId);
  }
}
