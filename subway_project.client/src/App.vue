<script setup>
import { RouterLink, RouterView } from "vue-router";
import TopNav from "./components/TopNav.vue";
import SideNav from "./components/SideNav.vue";
import MainPage from "./components/MainPage.vue";
import KitchenPage from "./components/KitchenPage.vue";
import CustomerOrderListPage from "./components/CustomerOrderListPage.vue";
</script>

<template>
  <nav>
    <RouterLink to="/">Home</RouterLink>
  </nav>

  <RouterView />

  <!-- <router-link to="/">Home</router-link>
  <router-link to="/order">About</router-link>
  <router-view/> -->
  <!-- <div class="page-container">
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

  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />

  <KitchenPage /> -->
</template>
