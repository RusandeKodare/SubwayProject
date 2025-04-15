<script setup>
import { ref, reactive, watch, onMounted } from "vue";

onMounted(() => {
  getProducts();
});

const baseUrl = "https://localhost:7193";

const props = defineProps({
  selectedSubCategory: Object,
  receivedList: {
    type: Array,
    default: () => [],
  },
  cartLimits: Object
});

const products = reactive([]);
const filteredProducts = ref([]);
let storedOrder = JSON.parse(localStorage.getItem("order"));
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




const emit = defineEmits(["emittedList"]);

function AddToCart(emittedProduct)
{
  storedOrder = JSON.parse(localStorage.getItem("order"));
  storedOrder.products.push(emittedProduct);
  storedOrder.totalPrice += emittedProduct.price;
  localStorage.setItem("order", JSON.stringify(storedOrder));
  console.log(storedOrder);
  props.receivedList.push(emittedProduct);
  emit("emittedList", [...props.receivedList]);
}

const IsDisabled = (subCatId) => {
  if (!props.cartLimits || !props.receivedList) {
    return false; // No limits or receivedList, so not disabled
  }

  if (props.selectedSubCategory.categoryId === 1 && props.selectedSubCategory.id !== 1) { //if category is "Sub", and subcategory is not "Bread"
    const cartHasBread = props.receivedList.findIndex(item => item.subCategoryId === 1) !== -1; //check if there is bread in the cart
    if (cartHasBread) { //if there is bread in the cart
      const itemCount = props.receivedList.filter(item => item.subCategoryId === subCatId).length; //check number of items of the subcategory in the cart
      return itemCount >= props.cartLimits[subCatId]; //return true/false depending on if the limit is reached
    }
    return true; //if there is no bread in the cart, return true to disable the button
  }

  //for any other subcategories check number of items of the subcategory in the cart, and return true/false depending on if the limit is reached
  const itemCount = props.receivedList.filter(item => item.subCategoryId === subCatId).length;
  return itemCount >= props.cartLimits[subCatId];
};



</script>

<template>

  <div v-if="showProducts" class="products-container">
    <div v-for="p in filteredProducts" :key="p.id" :id="`product-` + p.id" class="product">
      <img class="image" :src="p.imageUrl" alt="Product Image">
      <h1>{{ p.name }}</h1>
      <p>Price: {{ p.price }}kr</p>
      <button class="button" @click="AddToCart(p)" :disabled="IsDisabled(p.subCategoryId)">
        <!-- Visual Studio says "'IsDisabled(p.subCategoryId)' is not a valid value of attribute 'disabled'",
          but the functionality works as intended (i.e. the button is disabled if a certain amount of a product is in "items"). -->
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

  .product .button:disabled {
    background-color: #e2e8f0;
    color: #a0aec0;
    cursor: not-allowed;
  }

</style>
