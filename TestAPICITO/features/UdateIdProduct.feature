Feature: Update Product
  Como usuario
  Quiero poder actualizar un producto existente
  Para modificar su información

  Scenario: Update a product that exist
    Given I have the following product ID: 17
    And I have a product with the following details for update:
      | name    | description   | image       |  price     | categoryId  |
      | Purple Glasses  | Purple Glasses  | purple-glasses.jpg | 19.99          | 7              |
    When I send a PUT request to "/api/products/{productId}" with the product details
    Then the response status code can be 403
