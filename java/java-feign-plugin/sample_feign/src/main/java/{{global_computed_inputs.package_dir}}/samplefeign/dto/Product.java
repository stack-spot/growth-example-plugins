package {{global_computed_inputs.base_package}}.samplefeign.dto;

public class Product {

  private Integer id;
  private String title;
  private String description;
  private Long price;
  private Long discountPercentage;
  private Long rating;
  private String brand;
  private String category;

  public Integer getId() {
    return id;
  }

  public void setId(Integer id) {
    this.id = id;
  }

  public String getTitle() {
    return title;
  }

  public void setTitle(String title) {
    this.title = title;
  }

  public String getDescription() {
    return description;
  }

  public void setDescription(String description) {
    this.description = description;
  }

  public Long getPrice() {
    return price;
  }

  public void setPrice(Long price) {
    this.price = price;
  }

  public Long getDiscountPercentage() {
    return discountPercentage;
  }

  public void setDiscountPercentage(Long discountPercentage) {
    this.discountPercentage = discountPercentage;
  }

  public Long getRating() {
    return rating;
  }

  public void setRating(Long rating) {
    this.rating = rating;
  }

  public String getBrand() {
    return brand;
  }

  public void setBrand(String brand) {
    this.brand = brand;
  }

  public String getCategory() {
    return category;
  }

  public void setCategory(String category) {
    this.category = category;
  }
}
