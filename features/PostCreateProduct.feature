Feature: Create Product
  Como usuario
  Quiero poder crear un nuevo producto
  Para agregarlo al sistema

  Scenario: Crear un nuevo producto exitosamente
    Given I have a product with the following details:
      | name    | description   | image       |  price     | categoryId  |
      | Purple Glasses  | Purple Glasses  | purple-glasses.jpg | 19.99          | 7              |
    When I send a POST request to "/api/products" with the product details
    Then the response status code should be for the create 403