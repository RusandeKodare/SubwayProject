<script setup>
import { defineProps, ref, reactive, watch, computed } from "vue";
import { useRouter } from "vue-router";


const props = defineProps({
  receivedList: {
    type: Array,
    default: () => [],
  },
});


const totalPrice = computed(() => {
  let sum = 0;
  for (const item of props.receivedList) {
    sum += item.price || 0;
  }

  return sum;
});

const removeItem = (item) => {
  const index = props.receivedList.indexOf(item);
  props.receivedList.splice(index, 1);
}

</script>

<template>

  <div class="cart">
    <div class="cart-footer">


      <button @click="checkout">Order here</button>
    </div>
    <div class="cart-header">
      <span>
        Total: {{ totalPrice }} kr
      </span>
    </div>


    <div v-for="item in receivedList" class="cart-item">
      <span> {{ item.name }} {{ item.price }} kr </span>
      <button @click="removeItem">X</button>
    </div>


  </div>
</template>

<style scoped>
.cart {
  position:fixed;
  height: 100vh;
  width: 15%;
  background-color: #015643;
  box-shadow: -2px 0 8px rgba(0, 0, 0.1, 0.1);
  padding: 20px;
  overflow-y: auto;
  font-family: "Kanit", system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  color: white;
}
.cart-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-weight: 500;
  font-size: 1.2rem;
  margin-bottom: 20px;
  text-decoration-line: underline;
  text-decoration-color: yellow;
  font-size: 20px;
}
.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 15px;
  border-bottom: 1px solid #eee;
  padding-bottom: 10px;
}

.cart-item button {
  background-color: red;
  text-align: center;
  font-size: 1rem;
  color: white;
  width: 2vw;
  border: none;
  border-radius: 8px;
  font-weight: bold;
}
.cart-footer {
  margin-bottom: 20px;
  text-align: left;
}

.cart-footer button {
  display: block;
  background-color: #F4C12C;
  color: #215B35;
  padding: 10px 15px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  font-size: 15px;
  margin-top: 10px;
}

</style>

