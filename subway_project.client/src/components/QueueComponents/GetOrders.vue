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
    <h2>Food Orders</h2>

    <div v-if="loading">Loading orders...</div>
    <div v-if="error">Error: {{ error }}</div>

    <div class="left-div">
      <p>orderReceived</p>
      <ul v-if="!loading && !error">
        <li v-for="order in orders" :key="order.id">
          {{ order.id }} - {{ order.takeAway }} - {{ order.totalPrice }} - {{ order.orderReceived }}
        </li>
      </ul>
    </div>
    <br />
    <div class="right-div">
      <p>orderInProgress</p>
      <ul v-if="!loading && !error">
        <li v-for="order in orders" :key="order.id">
          {{ order.id }} - {{ order.takeAway }} - {{ order.totalPrice }} - {{ order.orderInProgress }}
        </li>
      </ul>
    </div>
  </div>
</template>

<style scoped>
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
</style>
