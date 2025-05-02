<script setup>
  import './assets/main.css';
  import { RouterLink, RouterView } from "vue-router";
  import TopNav from "./components/TopNav.vue";
  import SideNav from "./components/SideNav.vue";
  import MainPage from "./components/MainPage.vue";
  import KitchenPage from "./components/KitchenPage.vue";
  import CustomerOrderListPage from "./components/CustomerOrderListPage.vue";
</script>

<template>
  <RouterView />
</template>

