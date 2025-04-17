<script setup>
import '../assets/main.css';
import { ref } from "vue";
import MainPage from "../components/MainPage.vue";
import SideNav from "../components/SideNav.vue";
import TopNav from "../components/TopNav.vue";
import CartNav from '@/components/CartNav.vue';

const selectedSubCategory = ref(null);
let cartItems = ref([]);

const handleUpdatedCartItems = (updatedItems) => {
  cartItems.value = updatedItems;
}

const handleSubCategorySelected = (subcat) => {
  selectedSubCategory.value = subcat;
}

console.log(selectedSubCategory)


const cartLimits = {
  1: 1, //bread
  2: 5, //vegetables
  3: 1, //sauces
  4: 2, //cheese
  5: 2, //proteins
  6: 5, //carbonated
  7: 5, //non carbonated
  8: 5, //chips
  9: 5, //cookies
  10: 5, //ice cream
  11: 5 //pies
};

</script>

<template>
  <div class="page-container">
    <nav>
      <TopNav />
    </nav>
    <aside>
      <SideNav @subcategory-selected="handleSubCategorySelected"/>
    </aside>
    <section>
      <MainPage :selected-sub-category="selectedSubCategory" :received-list="cartItems" :cart-limits="cartLimits" @emitted-list="handleUpdatedCartItems" />
    </section>
    <div class="cart">
      <CartNav :received-list="cartItems" :cart-limits="cartLimits" @emitted-list="handleUpdatedCartItems" />
    </div>
  </div>


</template>

<style scoped>
section {
  overflow-y: auto;
}
</style>
