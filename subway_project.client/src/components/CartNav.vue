<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
</script>

<template>
  <div class="cart">
    <div class="cart-header">
      <span>Your Order</span>
    </div>

    <div v-for="item in items" :key="item.id" class="cart-item">
      <span>{{ item.name }}</span>
      <span>{{ item.price }} kr</span>
    </div>

    <div class="cart-footer">
      <strong>Totalt: {{ total }} kr</strong>
      <button @click="checkout">Till kassan</button>
    </div>
  </div>
</template>

<style scoped>
.cart {
  position:fixed;
  grid-column: 3/4;
  top:15vh;
  bottom: 150px;

  width: 250px;
  height: 400px;
  background-color: #015643;
  box-shadow: -2px 0 8px rgba(0, 0, 0.1, 0.1);
  padding: 20px;
  overflow-y: auto;
  /* z-index: 1000; */
  /* transition: transform 0.3s ease-in-out;
  transform: translateX(100%); */
  border-radius: 10px;
  font-family: "Kanit", system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  color: white;
}
.cart-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-weight: bold;
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
.cart-footer {
  margin-top: 20px;
  text-align: right;
}

.cart-footer button {
  background-color: #F4C12C;
  color: #215B35;
  padding: 10px 15px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  font-size: 15px;
}

.cart-footer button:hover {
  background-color: #f7d46a;
}


/* .cart {
  position: fixed;
  top: 150px;
  bottom: 150px;
  right: 330px;
  width: 250px;
  height: 500px;
  background-color: #F4C12C;
  box-shadow: -2px 0 8px rgba(0, 0, 0.1, 0.1);
  padding: 20px;
  overflow-y: auto;
  z-index: 1000;
  transition: transform 0.3s ease-in-out;
  transform: translateX(100%);
  border-radius: 10px;
  font-family: "Kanit", system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  color: white;
}
.cart-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-weight: bold;
  font-size: 1.2rem;
  margin-bottom: 20px;
  text-decoration-line: underline;
  text-decoration-color: green;
  font-size: 20px;
}
.cart-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 15px;
  border-bottom: 1px solid #eee;
  padding-bottom: 10px;
}
.cart-footer {
  margin-top: 20px;
  text-align: right;
}

.cart-footer button {
  background-color: #015643;
  color: #F4C12C;
  padding: 10px 15px;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  font-size: 15px;
}

.cart-footer button:hover {
  background-color: #155748;
} */
</style>

