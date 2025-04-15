<script setup>
  import { ref, onMounted } from 'vue'

const orders = ref([])
const loading = ref(true)
const error = ref(null)

onMounted(async () => {
  try {
    const response = await fetch('/api/Orders')
    if (!response.ok) {
      throw new Error('Failed to fetch orders')
    }
    orders.value = await response.json()
  } catch (err) {
    error.value = err.message
  } finally {
    loading.value = false
  }
})</script>

<template>
  <div>

    <div v-if="loading">Loading orders...</div>
    <div v-if="error">Error: {{ error }}</div>

  </div>
  <div class="order-page">
    <div class="header-div"></div>
    <div class="main-content">
      <div class="left-div">
        <h2>Orders Received</h2>
        <p>Order Id - TakeAway - Price - Time</p>
        <ul v-if="!loading && !error">
          <li v-for="order in orders.filter(o => o.orderReceived !== null &&
            o.orderInProgress == null &&
            o.orderReady == null &&
            o.orderCompleted == null)"
            :key="order.id">
            <div class="order-div">
              {{ order.id }} - {{ order.takeAway }} - {{ order.totalPrice }} - {{ order.orderReceived }}
            </div>
          </li>
        </ul>
      </div>
      <br />
      <div class="right-div">
        <h2>Orders In Progress</h2>
        <p>Order Id - TakeAway - Price - Time</p>
        <ul v-if="!loading && !error">
          <li v-for="order in orders.filter(o => o.orderInProgress !== null &&
              o.orderReady == null &&
              o.orderCompleted == null)"
              :key="order.id">
            <div class="order-div">
              {{ order.id }} - {{ order.takeAway }} - {{ order.totalPrice }} - {{ order.orderInProgress }}
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .order-page {
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
    flex-direction: row;
    justify-content: space-between;
    width: 100%;
    height: 100vh;
    overflow: hidden;
  }

  .left-div {
    width: 50%;
    background-color: #e0e0e0;
    padding: 20px;
    margin-left: 1.5rem;
    margin-right: 2rem;
    margin-bottom: 2rem;
    box-sizing: border-box;
    float: left;
    border: solid 5px blue;
  }

  .right-div {
    width: 50%;
    background-color: #e0e0e0;
    padding: 20px;
    margin-left: 1.5rem;
    margin-right: 2rem;
    margin-bottom: 2rem;
    box-sizing: border-box;
    float: left;
    border: solid 5px yellow;
  }

  .order-div {
    background-color: #f0f0f0;
    padding: 10px;
    margin: 5px 0;
    border-radius: 5px;
    border: solid 1px #ccc;
  }
</style>
