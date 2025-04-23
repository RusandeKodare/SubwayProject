<script setup>
  import { onMounted } from 'vue'
  import { useOrdersStore } from '@/stores/OrdersStore';
  import CustomerOrder from './CustomerOrder.vue';


  const ordersStore = useOrdersStore();

  onMounted(async () => {
    await ordersStore.getOrders();
  })

</script>

<template>
  <div>

    <div v-if="ordersStore.loading">Loading orders...</div>
    <div v-if="ordersStore.error">Error: {{ error }}</div>

  </div>
  <div class="order-page">
    <div class="header-div"></div>
    <div class="main-content">
      <div class="left-div">
        <CustomerOrder title="Orders Completed" :orders="ordersStore.FilteredOrdersRecieved":show="ordersStore.ShowOrders" />
      </div>

      <br />

      <div class="middle-div">
        <CustomerOrder title="Orders Completed" :orders="ordersStore.FilteredOrdersInProgress":show="ordersStore.ShowOrders" />
      </div>
      
      <br />

      <div class="right-div">
        <CustomerOrder title="Orders Completed" :orders="ordersStore.FilteredOrdersCompleted":show="ordersStore.ShowOrders" />
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

  /* .order-div {
    background-color: #f0f0f0;
    padding: 10px;
    margin: 5px 0;
    border-radius: 5px;
    border: solid 1px #ccc;
    display: inline-block;
    text-align: center;
  } */

  /* ul {
    display: flex;
    flex-wrap: wrap;
    gap: 10px;
    list-style: none;
    padding: 0;
  } */
</style>
