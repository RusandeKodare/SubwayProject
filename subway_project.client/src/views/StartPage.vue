<script setup>
import "../assets/main.css";
import { ref } from "vue";
import { useRouter } from "vue-router";
import TopNav from "@/components/TopNav.vue";
import { useOrderStore } from "@/stores/useOrderStore";

const orderStore = useOrderStore();

const order = {
  takeAway: false,
  totalPrice: 0,
  products: []
};


const router = useRouter();
const eatHere = () =>{
  order.takeAway = false;
  localStorage.setItem("order", JSON.stringify(order));
  console.log(order);
  orderStore.changeTakeAway(false);
  router.push("/order");
};

const takeAway = () =>{
  order.takeAway = true;
  localStorage.setItem("order", JSON.stringify(order));
  console.log(order);
  orderStore.changeTakeAway(true);
  router.push("/order");
};

</script>

<template>
    <nav>
      <TopNav />
    </nav>
    <div class="btn-container">
      <button class="btn eat-here" @click="eatHere">Eat here</button>
      <button class="btn to-go" @click="takeAway">To Go</button>
    </div>
</template>

<style scoped>
nav{
  height: 11vh;
}
.btn-container {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 40px;
  height: 60vh;
}
.btn {
  width: 150px;
  height: 150px;
  border: none;
  border-radius: 20px;
  font-size: 32px;
  font-weight: bold;
  line-height: 1.2;
  cursor: pointer;
  text-align: center;
  font-family: 'Arial Rounded MT Bold', 'Helvetica Rounded', Arial, sans-serif;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
  transition: transform 0.2s ease;
}
.btn:hover {
  transform: scale(1.05);
}
.eat-here {
  background-color: #F4C12C;
  color: #015643;
}
.to-go {
  background-color: #015643;
  color: #F4C12C;
}
</style>
