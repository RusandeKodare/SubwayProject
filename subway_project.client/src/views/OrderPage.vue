<script setup>
import '../assets/main.css';
import { ref } from "vue";
import MainPage from "../components/MainPage.vue";
import SideNav from "../components/SideNav.vue";
import TopNav from "../components/TopNav.vue";

</script>

<template>
  <div class="page-container">
    <nav>
      <TopNav />
    </nav>
    <aside>
      <SideNav />
    </aside>
    <section>
      <MainPage />
    </section>
  </div>


</template>
