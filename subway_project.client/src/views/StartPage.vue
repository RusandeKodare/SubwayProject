<script setup>
  import "../assets/main.css";
  import { ref } from "vue";
  import { useRouter } from "vue-router";
  import TopNav from "@/components/TopNav.vue";
  import { useOrderStore } from "@/stores/useOrderStore";
  import { useSubStore } from "@/stores/SubStore";

  const orderStore = useOrderStore();
  const subStore = useSubStore();
  const router = useRouter();

  const eatHere = () => {
    orderStore.changeTakeAway(false);
    router.push("/order");
  };

  const takeAway = () => {
    orderStore.changeTakeAway(true);
    router.push("/order");
  };
</script>

<template>
  <div class="kitchen-queue-page-container">
    <nav>
      <TopNav />
    </nav>
    <div class="btn-container">
      <button class="btn eat-here" @click="eatHere">Eat here</button>
      <button class="btn to-go" @click="takeAway">Takeaway</button>
    </div>
  </div>
</template>

<style scoped>
  nav {
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
