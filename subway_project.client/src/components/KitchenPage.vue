<script setup>
  import { onMounted } from 'vue'
  import { useOrdersStore } from '@/stores/OrdersStore'

  const ordersStore = useOrdersStore();

  onMounted(async () => {
    await ordersStore.getOrders();
  })

function sortedProducts(products) {
  return [...products].sort((a, b) => a.SubCategoryId - b.SubCategoryId)
}

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
        <h2>Orders Received</h2>
        <ul v-if="ordersStore.ShowOrders">
            <li v-for="order in ordersStore.FilteredOrdersRecieved" :key="order.id">
              <div class="order-div">
                <div class="order-heading">
                  ID: {{ order.id }} - {{ order.takeAway ? "Take Away" : "Eat Here" }} 
                </div> 
                <div v-for="p in sortedProducts(order.products)">
                  {{ p.name }}
                </div>
              </div>
            </li>
        </ul>
      </div>
      <br />
      <div class="right-div">
        <h2>Orders In Progress</h2>
        <ul v-if="ordersStore.ShowOrders">
          <li v-for="order in ordersStore.FilteredOrdersInProgress"
              :key="order.id">
              <div class="order-div">
              <div class="order-heading">
                ID: {{ order.id }} - {{ order.takeAway ? "Take Away" : "Eat Here" }} 
              </div> 
              <div v-for="p in order.products">
                {{ p.name }}
              </div>
            </div>
          </li>
        </ul>
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

  .left-div, .right-div {
    width: 50%;
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

  .right-div {
    border-color: yellow;
    margin-left: 1rem;
    margin-right: 2rem;
  }

  .order-div {
    display: inline-block;
    background-color: #f0f0f0;
    padding: 10px;
    margin: 5px;
    border-radius: 5px;
    border: solid 1px #ccc;
    text-align: center;
  }

  ul {
    display: flex;
    flex-wrap: wrap;
    list-style: none;
    padding: 0;
  }

  .order-heading {
    margin-bottom: 0.5rem;
    font-weight: bold;
  }
</style>