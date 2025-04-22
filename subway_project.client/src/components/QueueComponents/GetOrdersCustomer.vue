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
  })
  </script>

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
              {{ order.id }}
            </div>
          </li>
        </ul>
      </div>
      <br />
      <div class="middle-div">
        <h2>Orders In Progress</h2>
        <p>Order Id - TakeAway - Price - Time</p>
        <ul v-if="!loading && !error">
          <li v-for="order in orders.filter(o => o.orderInProgress !== null &&
              o.orderReady == null &&
              o.orderCompleted == null)"
              :key="order.id">
            <div class="order-div">
              {{ order.id }}
            </div>
          </li>
        </ul>
      </div>
      <div class="right-div">
        <h2>Orders Completed</h2>
        <p>Order Id - TakeAway - Price - Time</p>
        <ul v-if="!loading && !error">
          <li v-for="order in orders.filter(o => o.orderCompleted !== null &&
              o.orderCollected == null)"
              :key="order.id">
            <div class="order-div">
              {{ order.id }}
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

  .order-div {
    background-color: #f0f0f0;
    padding: 10px;
    margin: 5px 0;
    border-radius: 5px;
    border: solid 1px #ccc;
    display: inline-block;
    text-align: center;
  }

  ul {
    display: flex;
    flex-wrap: wrap;
    gap: 10px;
    list-style: none;
    padding: 0;
  }
</style>
