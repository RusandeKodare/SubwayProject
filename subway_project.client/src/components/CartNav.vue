<script setup>
import { defineProps, ref, reactive, watch, computed } from "vue";
import { useRouter } from "vue-router";

let storedOrder = JSON.parse(localStorage.getItem("order"));

const props = defineProps({
  receivedList: {
    type: Array,
    default: () => [],
  },
  cartLimits: Object
});


const totalPrice = computed(() => {
  let sum = 0;
  for (const item of props.receivedList) {
    sum += item.price || 0;
  }

  return sum;
});


const groupedList = computed(() => {
  const map = {}
  for (const item of props.receivedList) {
    if (!map[item.name]) {
      map[item.name] = { ...item, quantity: 1 }
    } else {
      map[item.name].quantity += 1
    }
  }
  return Object.values(map)
});

const checkout = () => {
  storedOrder = JSON.parse(localStorage.getItem("order"));
  console.log(storedOrder);
  fetch("api/Orders", {
  method: "POST",
  headers: {
    "Content-Type": "application/json",
  },
  body: JSON.stringify(storedOrder),
})
.then ((response) => {
  if (response.ok){
    console.log("order was saved successfully to database");
    localStorage.removeItem("order");
  }
  else{
    console.log("Something went wrong when saving the order to the database");
  }
  
});
};

  const emit = defineEmits(["emittedList"]);

const removeItem = (item) => {
  const index = props.receivedList.findIndex(i => i.name === item.name && i.subCategoryId === item.subCategoryId);
  if (index === -1) {
    console.error("Item not found in receivedList");
    return;
  }
  storedOrder = JSON.parse(localStorage.getItem("order"));
  storedOrder.products.splice(index, 1);
  storedOrder.totalPrice -= item.price;
  localStorage.setItem("order", JSON.stringify(storedOrder));
  console.log(storedOrder);
  props.receivedList.splice(index, 1);
  emit("emittedList", [...props.receivedList]);
};

  const addItem = (item) => {
    storedOrder = JSON.parse(localStorage.getItem("order"));
    storedOrder.products.push(item);
    storedOrder.totalPrice += item.price;
    localStorage.setItem("order", JSON.stringify(storedOrder));
    console.log(storedOrder);
  const index = props.receivedList.indexOf(item);
  props.receivedList.push(item);
  emit("emittedList", [...props.receivedList]);
};


  const IsDisabled = (subCatId) => {
    const itemCount = props.receivedList.filter(item => item.subCategoryId === subCatId).length;
    return itemCount >= props.cartLimits[subCatId];
  };

</script>

<template>

  <div class="cart">


    <div class="cart-header">
      <span v-if="props.receivedList.length > 0">
        <div class="cart-footer">
          <button @click="checkout">Finalize order</button>
        </div>
        Total: {{ totalPrice }} kr
      </span>
      <span v-else>
        Welcome!
        <br><br>
        Choose between our delicious dishes!
        
      </span>
    </div>

    <div v-for="item in groupedList" :key="item.name" class="cart-item">
      <span>{{ item.name }} x {{ item.quantity }} — {{ item.price }} kr</span>
      <button @click="addItem(item)" :disabled="IsDisabled(item.subCategoryId)">+</button>
      <!-- Visual Studio says "'IsDisabled(item.subCategoryId)' is not a valid value of attribute 'disabled'",
      but the functionality works as intended (i.e. the button is disabled if a certain amount of a product is in "groupedList"). -->
      <button @click="removeItem(item)">-</button>
    </div>

  </div>
</template>

<style scoped>
.cart {
  width: 90%;
  max-width: 600px;
  padding: 10px;
  background-color: #f9f9f9;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
}

.cart-header {
  text-align: center;
  font-size: 1.5rem;
  font-weight: bold;
  margin: 10px;
  color: #333;
}

.cart-footer {
  display: flex;
  justify-content: center;
  margin: 20px;
}

.cart-footer button {
  background-color: #38a169;
  color: white;
  padding: 12px 24px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s ease;
}

.cart-footer button:hover {
  background-color: #2f855a;
}

.cart-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: white;
  padding: 12px;
  margin-bottom: 10px;
  border-radius: 8px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
  font-size: 1.1rem;
}

.cart-item span {
  font-weight: 500;
  color: #555;
}

.cart-item button {
  background-color: #e2e8f0;
  border: none;
  color: #333;
  padding: 6px 12px;
  border-radius: 6px;
  cursor: pointer;
  transition: background-color 0.3s ease, color 0.3s ease;
}

.cart-item button:hover {
  background-color: #edf2f7;
  color: #2d3748;
}

.cart-item button:active {
  background-color: #cbd5e0;
}

  .cart-item button:disabled {
    background-color: #e2e8f0;
    color: #a0aec0;
    cursor: not-allowed;
  }
</style>
