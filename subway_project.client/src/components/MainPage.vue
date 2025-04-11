<script setup>
import { ref, watch, onMounted } from "vue";

const baseUrl = "https://localhost:7193";

const props = defineProps({
  selectedSubCategory: Object
});

const products = ref([]);
const filteredProducts = ref([]);

var showProducts = ref(false);

const getProducts = async () => {
  const response = await fetch(baseUrl + "/api/products");
  const data = await response.json();
  products.value = data;

  showProducts.value = !showProducts.value;
};

watch(
  () => props.selectedSubCategory,
  (newSubCat) => {
    if (!newSubCat) {
      filteredProducts.value = [];
      return;
    }

    filteredProducts.value = products.value.filter(
      (p) => p.subCategoryId === newSubCat.id
    );
  },
  { immediate: true }
);

onMounted(() => {
  getProducts();
})


</script>

<template>
  <!-- <button class="bottom-link-products" @click="getProducts">Click Me</button> -->
  <div v-if="showProducts" class="products-container">
    <div v-for="p in filteredProducts" :key="p.id" :id="`product-` + p.id" class="product">
      <div class="product"></div>
      <h1>{{ p.name }}</h1>
      <p>Price: {{ p.price }}kr</p>
      <img :src="p.imageUrl" alt="Product Image" />
      <button>
        click me
      </button>
    </div>
  </div>
</template>

<style>
.products-container {
  display: flex;
  flex-direction: column;
  gap: 2px;
  overflow-y: auto;
}

.product {
  border: 1px solid #ccc;
  padding: 40px;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 90px;
  flex-wrap: wrap;
  background-color: white;
  border-radius: 5px;
  box-shadow: 3px 10px 5px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s;
  transform: scale(1);
  flex-direction: column;

}

</style>
