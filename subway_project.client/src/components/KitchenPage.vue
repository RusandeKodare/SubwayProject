<script setup>
  import { onMounted } from 'vue'
  import { useOrdersStore } from '@/stores/OrdersStore'
  import KitchenOrder from './KitchenOrder.vue';

  const ordersStore = useOrdersStore();

  onMounted(async () => {
    await ordersStore.getOrders();
  })
</script>

<template>
  <div>

    <div v-if="ordersStore.loading">Loading orders...</div>
    <div v-if="ordersStore.error">Error: {{ ordersStore.error }}</div>

  </div>
  <div class="order-page">
    <div class="header-div"></div>
    <div class="main-content">
      <div class="left-div">
        <KitchenOrder type="received" />
      </div>

      <div class="middle-div">
        <KitchenOrder type="inProgress" />
      </div>

      <div class="right-div">
        <KitchenOrder type="completed" />
      </div>

    </div>
  </div>
</template>

<style scoped>
  .order-page {
    height: 100vh;
    display: flex;
    flex-direction: column;
  }

  .header-div {
    width: 100%;
    height: 50px;
    color: white;
    text-align: center;
    line-height: 50px;
  }

  .main-content {
    display: flex;
    flex: 1;
    flex-direction: row;
    justify-content: space-between;
    overflow: hidden;
  }

  .left-div, .middle-div, .right-div {
    width: 30%;
    background-color: #e0e0e0;
    padding: 20px;
    margin-bottom: 2rem;
    box-sizing: border-box;
    border: solid 5px;
    overflow-y: auto;
    max-height: 100%;
  }

  .left-div {
    border-color: blue;
    margin-right: 1rem;
    margin-left: 2rem;
  }

  .middle-div {
    border-color: yellow;
    margin-left: 1rem;
    margin-right: 1rem;
  }

  .right-div {
    border-color: green;
    margin-left: 1rem;
    margin-right: 2rem;
  }

</style>
