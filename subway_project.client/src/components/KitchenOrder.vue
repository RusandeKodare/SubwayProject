<script setup>
  import { useOrdersStore } from '@/stores/OrdersStore'
  import { defineProps } from 'vue';

  const ordersStore = useOrdersStore();

  const props = defineProps({
    orders: Array,
    title: String,
    show: Boolean
  });

async function updateOrder(order) {
    if(order.OrderInProgress == null) {
        await ordersStore.progressOrder(order.id);
        console.log("Order moved to in progress")
    }

    //FUNKAR INTE ÄN
    else{
        await ordersStore.completeOrder(order.id)
    }
  };

  //   function sortedProducts(products) {
//   return [...products].sort((a, b) => a.SubCategoryId - b.SubCategoryId)
// }

</script>

<template>
    <h2>{{ props.title }}</h2>
    <ul v-if="props.show">
        <li v-for="order in props.orders" :key="order.id">
            <button class="order-div" @click="updateOrder(order)">
                <div class="order-heading">
                  ID: {{ order.id }} - {{ order.takeAway ? "Take Away" : "Eat Here" }} 
                </div> 
                <div v-for="p in order.products">
                  {{ p.name }}
                </div>
            </button>
        </li>
    </ul>
</template>

<style>
  .order-heading {
    margin-bottom: 0.5rem;
    font-weight: bold;
  }
</style>