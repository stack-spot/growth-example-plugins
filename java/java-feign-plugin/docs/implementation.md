#### **Automatic Configurations**

The plugin creates a sample class with a dummy Feign client.

```java
@FeignClient(
    value = "${sample.feign.name}",
    url = "${sample.feign.url}"
)
public interface ISampleFeignClient {

  @RequestMapping(methos = GET, value = "/products")
  List<Product> fetchProductList();

  @RequestMapping(methos = GET, value = "/products/{productId}")
  Product fetchProduct(@PathVariable("productId") Integer productId);
}
```

The plugin also adds the dependency based on the selected *build_tool*:

**Gradle:**  
Java 17:  
`implementation 'org.springframework.cloud:spring-cloud-starter-openfeign:4.0.1'`

Java 8-11:  
`implementation 'org.springframework.cloud:spring-cloud-starter-openfeign:3.1.6'`

**Maven:**  
Java 17:  
```xml
<dependency>
  <groupId>org.springframework.cloud</groupId>
  <artifactId>spring-cloud-starter-openfeign</artifactId>
  <version>4.0.1</version>
</dependency>
```

Java 8-11:  
```xml
<dependency>
  <groupId>org.springframework.cloud</groupId>
  <artifactId>spring-cloud-starter-openfeign</artifactId>
  <version>3.1.6</version>
</dependency>
```
