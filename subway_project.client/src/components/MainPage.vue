<script setup>
import { ref, reactive, watch, onMounted } from "vue";

const baseUrl = "https://localhost:7193";

const props = defineProps({
  selectedSubCategory: Object
});

const products = reactive([]);
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


let items = reactive([]);
const emit = defineEmits(["emittedList"]);

function AddToCart(emittedProduct)
{
  items.push(emittedProduct);
  emit("emittedList", [...items]);
}




</script>

<template>
  <div v-if="showProducts" class="products-container">
    <div v-for="p in filteredProducts" :key="p.id" :id="`product-` + p.id" class="product">
      <h1>{{ p.name }}</h1>
      <p>Price: {{ p.price }}kr</p>
      <img class="image" :src="'https://dynl.mktgcdn.com/p/pnVqdWjzy9d8pi1-lxQK-eV3NDIZQVAPliizLM7nG_A/1900x1520.jpg'" alt="Product Image" />
      <button class="button" @click="AddToCart(p)">
        Buy me
      </button>
    </div>
  </div>
</template>

<style>

.image{
  width: 55%;
  height: auto;
  border-radius: 5px;
}
.products-container {
  margin: 20px;
  height: 100vh;
}

.product {
  display: flex;
  flex-direction: column;
  height: 30vh;
  margin: 10px;
  justify-content: center;
  align-items: center;
  border: 1px solid black;
  flex-wrap: wrap;
  background-color: rgb(90, 190, 128);
  border-radius: 25px;
}

.button{
  background-color: rgb(223, 230, 137);
  height: 30px;
  width: 100px;
  border-radius: 50px;
  margin: 10px;
  cursor: pointer;
}

</style>
