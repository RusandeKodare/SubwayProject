<script setup>
import { ref, reactive, watch, onMounted } from "vue";

onMounted(() => {
  getProducts();
});

const baseUrl = "https://localhost:7193";

const props = defineProps({
  selectedSubCategory: Object
});

const products = reactive([]);
const filteredProducts = ref([]);
const storedOrder = JSON.parse(localStorage.getItem("order"));
let showProducts = ref(false);

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




let items = reactive([]);
const emit = defineEmits(["emittedList"]);

function AddToCart(emittedProduct)
{
  storedOrder.products.push(emittedProduct);
  storedOrder.totalPrice += emittedProduct.price;
  localStorage.setItem("order", JSON.stringify(storedOrder));
  console.log(storedOrder);
  items.push(emittedProduct);
  emit("emittedList", [...items]);
}




</script>

<template>

  <div v-if="showProducts" class="products-container">
    <div v-for="p in filteredProducts" :key="p.id" :id="`product-` + p.id" class="product">
      <img class="image" :src="p.imageUrl" alt="Product Image">
      <h1>{{ p.name }}</h1>
      <p>Price: {{ p.price }}kr</p>
      <button class="button" @click="AddToCart(p)">
        EAT ME!
      </button>
    </div>
  </div>

</template>

<style>
h1 {
  font-size: 1.2rem;
  margin: 12px 0 6px;
  text-align: center;
}
.image{
  width: 100%;
  height: 300px;
  object-fit: cover;

}
.products-container {
  margin: 20px;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

.product {
  background-color: #ffffff;
  border-radius: 16px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  flex: 1 1 22vw;
  max-width: 22vw;
  padding: 16px;
  margin: 12px;
  transition: transform 0.2s ease, box-shadow 0.2s ease;
  cursor: pointer;
}
.product:hover {
  transform: translateY(-5px);
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.15);
}
.product .button {
  background-color: #38a169;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 8px;
  margin-top: 10px;
  transition: background-color 0.2s ease;
}

.product .button:hover {
  background-color: #2f855a;
}

</style>
