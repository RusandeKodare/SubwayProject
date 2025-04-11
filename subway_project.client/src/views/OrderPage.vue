<script setup>
import '../assets/main.css';
import { ref } from "vue";
import MainPage from "../components/MainPage.vue";
import SideNav from "../components/SideNav.vue";
import TopNav from "../components/TopNav.vue";
import CartNav from '@/components/CartNav.vue';

const selectedSubCategory = ref(null)

const handleSubCategorySelected = (subcat) => {
  selectedSubCategory.value = subcat;
}

console.log(selectedSubCategory)

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
      <MainPage :selected-sub-category="selectedSubCategory" />
    </section>
    <div >
      <CartNav />
    </div>
  </div>


</template>

<style scoped>
section {
  grid-column: 2/3;
  margin: 0 auto;
  padding: 20px;
  width: 100%;
  height: 100vh;
  overflow-y: auto;
}
</style>
