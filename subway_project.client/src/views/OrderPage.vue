<script setup>
import '../assets/main.css';
import { ref } from "vue";
import MainPage from "../components/MainPage.vue";
import SideNav from "../components/SideNav.vue";
import TopNav from "../components/TopNav.vue";
import CartNav from '@/components/CartNav.vue';

const selectedSubCategory = ref(null)
let list = ref([]);

function setList(emittedList) {
  list.value = [...emittedList];
}

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
      <MainPage :selected-sub-category="selectedSubCategory" @emitted-list="setList" />
    </section>
    <div class="cart" >
      <CartNav :received-list="list" />
    </div>
  </div>


</template>

<style scoped>
section {
  overflow-y: auto;
}
</style>
