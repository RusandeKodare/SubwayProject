<script setup>
import { useOrdersStore } from '@/stores/OrdersStore'
import { defineProps, computed, onMounted } from 'vue';

const ordersStore = useOrdersStore();

const props = defineProps({
  type: String // "received", "inProgress", or "completed"
});

onMounted(() => {
  ordersStore.getOrders();
  setTimeout(() => {
    console.log("Orders:", ordersStore.Orders);
  }, 500);
});


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
});

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
});

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
</script>

<template>
  <h2>{{ title }}</h2>
  <ul class="order-list" v-if="ordersStore.ShowOrders">
    <li v-for="order in filteredOrders" :key="order.id">
      <button class="order-div" @click="updateOrder(order)">
        <div class="order-heading">
          Order: {{ order.id }} - {{ order.takeAway ? 'Takeaway' : 'Eat Here' }}
        </div>

        <!-- Visa specials -->
        <div v-for="os in order.orderSpecials" :key="os.specialId">
          <p><strong>Special ({{ os.special.name }}):</strong> x {{ os.quantity }}</p>
          <ul>
            <li v-for="sp in os.special.specialProducts" :key="sp.productId">
              {{ sp.product.name }}
            </li>
             <br>
          </ul>
        </div>

        <!-- Sub -->
        <div v-for="(sub, subIndex) in order.subs" :key="sub.id">
          <p><strong>Sub: {{ subIndex + 1 }}</strong></p>
          <div v-for="subprod in sub.subProducts" :key="subprod.productId">
            <ul>
              <li> {{ subprod.product.name }} x {{ subprod.quantity }}</li>
            </ul>
          </div>
           <br>
        </div>

        <!-- Drinks -->
        <div v-if="order.orderProducts.filter(op => op.product.categoryId === 3).length">
          <p><strong>Drinks:</strong></p>
          <ul>
            <li v-for="op in order.orderProducts.filter(op => op.product.categoryId === 3)" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
             <br>
          </ul>
        </div>

        <!-- Snacks -->
        <div v-if="order.orderProducts.filter(op => op.product.categoryId === 4).length">
          <p><strong>Snacks:</strong></p>
          <ul>
            <li v-for="op in order.orderProducts.filter(op => op.product.categoryId === 4)" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
            <br>
          </ul>
        </div>

        <!-- Desserts -->
        <div v-if="order.orderProducts.filter(op => op.product.categoryId === 5).length">
          <p><strong>Desserts:</strong></p>
          <ul>
            <li v-for="op in order.orderProducts.filter(op => op.product.categoryId === 5)" :key="op.product.id">
              {{ op.product.name }} x {{ op.quantity }}
            </li>
             <br>
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
  font-size: 18px;
}

.order-div:hover {
  background-color: lightgreen;
}
</style>
