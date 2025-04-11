<script setup>

  import "../assets/main.css";
  import { ref } from "vue";
  import { useRouter } from "vue-router";
  import TopNav from "@/components/TopNav.vue";
  import KitchenPage from "@/components/KitchenPage.vue";

</script>

<template>

  <div>
    <nav>
      <TopNav />
    </nav>
    <div>
      <KitchenPage />
    </div>
  </div>

</template>

<style>

</style>
