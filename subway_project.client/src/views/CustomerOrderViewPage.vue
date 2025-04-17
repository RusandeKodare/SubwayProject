<script setup>

  import "../assets/main.css";
  import { ref } from "vue";
  import { useRouter } from "vue-router";
  import TopNav from "@/components/TopNav.vue";
  import CustomerOrderListPage from "@/components/CustomerOrderListPage.vue";

</script>

<template>

  <div class="kitchen-queue-page-container">
    <nav>
      <TopNav />
    </nav>
    <section>
      <CustomerOrderListPage />
    </section>
  </div>

</template>

<style>
</style>
