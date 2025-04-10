﻿using subway_shared.DTOs.CategoryDTOs;

namespace subway_shared.DTOs.ProductDTOs;

public class ProductGetDTO
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public decimal Price { get; set; }
	public int SubCategoryId { get; set; }
	public SubCategoryDTO.SubCategoryDTO? SubCategory { get; set; }
	public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
}