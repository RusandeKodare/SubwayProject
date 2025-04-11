<script setup>
import "../assets/main.css";
import { ref } from "vue";
import { useRouter } from "vue-router";
import TopNav from "@/components/TopNav.vue";

const router = useRouter();

const GoToMainPage = () => {
  router.push("/order");
};
</script>

<template>

  <div class="page-container">
    <nav>
      <TopNav />
    </nav>


    <div class="btn-container">
      <button class="btn eat-here" @click="GoToMainPage">Eat here</button>
      <button class="btn to-go" @click="GoToMainPage">To Go</button>
    </div>
  </div>


</template>

<style scoped>
.btn-container {
  display: flex;
  justify-content: center; /* horizontal center */
  align-items: center;   /* vertical center */
  gap: 40px;               /* space between buttons */
  grid-column: 1/3;
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
  /* gul */
  color: #215B35;
  /* mörkgrön text */
}
.to-go {
  background-color: #215B35;
  /* mörkgrön bakgrund */
  color: #F4C12C;
  /* gul text */
}
</style>
