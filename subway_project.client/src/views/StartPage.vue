<script setup>
import "../assets/main.css";
import { ref } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();

const GoToMainPage = () => {
  router.push("/order");
};
</script>

<template>
  <div class="page-container">
    <h1>Welcome to SubWay</h1>

    <button @click="GoToMainPage">To Go</button>
    <button @click="GoToMainPage">Eat here</button>

  </div>
</template>
