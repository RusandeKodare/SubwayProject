<script setup>
import { ref } from "vue";

const baseUrl = "https://localhost:7193";
const categories = ref([
    { name: "Sub", showSubCategories: false},
    { name: "Drinks", showSubCategories: false },
    { name: "Snacks", showSubCategories: false },
    { name: "Desserts", showSubCategories: false },
]);
const subCategories = ref([
    { name: "Bread"},
    { name: "Vegetables" },
    { name: "Sauces" },
    { name: "Cheese" },
    { name: "Proteins" },
]);

const GetCategories = async () => {
    const response = await fetch(baseUrl + "/api/categories");
    const data = await response.json();
    categories.value = data;
}

const toggleSubCategories = async (category) => {
    if (category.Name === "Sub") {
        category.showSubCategories = !category.showSubCategories;
    }
    await GetCategories();
    console.log(categories.value);
}

</script>
  
<template>
    <div class="side-nav-container">
        <div class="big-btn-container" v-for="(category, index) in categories" :key="index">
            <button :class="['bigmenuitem', { 'active': category.showSubCategories }]" @click="toggleSubCategories(category)">
            {{ category.name }}
          </button>
          <div v-if="category.showSubCategories" class="subcategories">
            <div class="sub-btn-container">
                <button v-for="(subCategory, subIndex) in subCategories" :key="subIndex" href="#" class="subcat-btn">
                    {{ subCategory.name }}
                </button>
            </div>
        </div>
        </div>
    </div>
  </template>