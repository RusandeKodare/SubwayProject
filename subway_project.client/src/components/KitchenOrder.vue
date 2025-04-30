<script setup>
  import { useOrdersStore } from '@/stores/OrdersStore'
  import { defineProps, computed } from 'vue';

  const ordersStore = useOrdersStore()

  const props = defineProps({
    type: String // "received", "inProgress", or "completed"
  })

  const title = computed(() => {
    switch (props.type) {
      case 'received':
        return 'Orders Received'
      case 'inProgress':
        return 'Orders In Progress'
      case 'completed':
        return 'Orders Completed'
      case 'collected':
        return 'Orders Collected'
      default:
        return ''
    }
  })

  const filteredOrders = computed(() => {
    switch (props.type) {
      case 'received':
        return ordersStore.FilteredOrdersRecieved
      case 'inProgress':
        return ordersStore.FilteredOrdersInProgress
      case 'completed':
        return ordersStore.FilteredOrdersCompleted
      case 'collected':
        return ordersStore.FilteredOrdersCollected
      default:
        return []
    }
  })

  async function updateOrder(order) {
    if (order.orderInProgress == null && order.orderCompleted == null && order.orderCollected == null) {
      await ordersStore.progressOrder(order.id);
      console.log("Order moved to in progress");
      return;
    }

    if (order.orderCompleted == null && order.orderCollected == null) {
      await ordersStore.completeOrder(order.id);
      console.log("Order moved to completed");
      return;
    }

    if (order.orderCollected == null) {
      await ordersStore.collectOrder(order.id);
      console.log("Order moved to collected");
      return;
    }
  }

  const groupedList = (products) => {
    const map = {}
    for (const product of products) {
      if (!map[product.name]) {
        map[product.name] = { ...product, quantity: 1 }
      } else {
        map[product.name].quantity += 1
      }
    }
    return Object.values(map)
  }

</script>

<template>
  <h2>{{ title }}</h2>
  <ul class="order-list" v-if="ordersStore.ShowOrders">
    <li v-for="order in filteredOrders" :key="order.id">
      <button class="order-div" @click="updateOrder(order)">
        <div class="order-heading">
          Order: {{ order.id }} - {{ order.takeAway ? 'Take Away' : 'Eat Here' }}
        </div>

        <!-- Sub -->
    <div v-for="(sub, subIndex) in order.subs" :key="sub.id">
      <p><strong>Sub: {{ subIndex + 1 }}</strong></p>
      <div v-for="subprod in sub.subProducts" :key="subprod.productId">
        <ul>
          <li> {{ subprod.product.name }} x {{ subprod.quantity }}</li>
        </ul>
      </div>
    </div>

        <!-- Drinks -->
        <div v-if="groupedList(order.orderProducts.filter(op => op.product.categoryId === 3)).length">
          <p><strong>Drinks:</strong></p>
          <ul>
            <li v-for="op in groupedList(order.orderProducts.filter(op => op.product.categoryId === 3))" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
          </ul>
        </div>

        <!-- Snacks -->
        <div v-if="groupedList(order.orderProducts.filter(op => op.product.categoryId === 4)).length">
          <p><strong>Snacks:</strong></p>
          <ul>
            <li v-for="op in groupedList(order.orderProducts.filter(op => op.product.categoryId === 4))" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
          </ul>
        </div>

        <!-- Desserts -->
        <div v-if="groupedList(order.orderProducts.filter(op => op.product.categoryId === 5)).length">
          <p><strong>Desserts:</strong></p>
          <ul>
            <li v-for="op in groupedList(order.orderProducts.filter(op => op.product.categoryId === 5))" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
          </ul>
        </div>
      </button>
    </li>
  </ul>
</template>

<style scoped>
  .order-heading {
    margin-bottom: 0.5rem;
    font-weight: bold;
  }

  .order-div {
    cursor: pointer;
    transition: background-color 0.3s ease;
  }

  .order-div:hover {
    background-color: lightgreen;
  }
</style>
