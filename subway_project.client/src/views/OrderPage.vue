<script setup>
import '../assets/main.css';
import { ref } from "vue";
import MainPage from "../components/MainPage.vue";
import SideNav from "../components/SideNav.vue";
import TopNav from "../components/TopNav.vue";
import CartNav from '@/components/CartNav.vue';

const selectedSubCategory = ref(null);
let cartItems = ref([]);

const handleSubCategorySelected = (subcat) => {
  selectedSubCategory.value = subcat;
}

console.log(selectedSubCategory)


const cartLimits = {
  1: 1, //bread
  2: 2, //proteins
  3: 5, //vegetables
  4: 1, //sauces
  5: 2, //cheese
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
      <MainPage :selected-sub-category="selectedSubCategory" :cart-limits="cartLimits" />
    </section>
    <div class="cart">
      <CartNav :cart-limits="cartLimits" />
    </div>
  </div>


</template>

<style scoped>
section {
  overflow-y: auto;
}
</style>
