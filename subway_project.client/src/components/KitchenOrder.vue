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

  const groupedList = (products) => {
    const map = {};
    for (const product of products) {
      if (!map[product.name]) {
        map[product.name] = { ...product, quantity: 1 };
      } else {
        map[product.name].quantity += 1;
      }
    }
    return Object.values(map);
  };

</script>

<template>
  <h2>{{ props.title }}</h2>
  <ul class="order-list" v-if="props.show">
    <li v-for="order in props.orders" :key="order.id">
      <button class="order-div" @click="updateOrder(order)">
        <div class="order-heading">
          Order: {{ order.id }} - {{ order.takeAway ? "Take Away" : "Eat Here" }}
        </div>

        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 1 && p.subCategoryId <= 5)).length">
          <p><strong>Sub:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 1 && p.subCategoryId <= 5))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>

        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 6 && p.subCategoryId <= 7)).length">
          <p><strong>Drinks:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 6 && p.subCategoryId <= 7))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>

        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 8 && p.subCategoryId <= 9)).length">
          <p><strong>Snacks:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 8 && p.subCategoryId <= 9))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
        </div>

        <div v-if="groupedList(order.products.filter(p => p.subCategoryId >= 10 && p.subCategoryId <= 11)).length">
          <p><strong>Desserts:</strong></p>
          <ul>
            <li v-for="product in groupedList(order.products.filter(p => p.subCategoryId >= 10 && p.subCategoryId <= 11))" :key="product.id">
              {{ product.name }} x {{ product.quantity }}
            </li>
          </ul>
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
