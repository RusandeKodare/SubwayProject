import { ref, computed } from "vue";
import { defineStore } from "pinia";

export const useOrdersStore = defineStore("ordersStore", () => {
  const orders = ref([]);
  const loading = ref(true);
  const error = ref("");

  async function getOrders() {
    try {
      const response = await fetch('/api/Orders')
      if (!response.ok) {
        throw new Error('Failed to fetch orders')
      }
      orders.value = await response.json()
    }
    catch (err) {
      error.value = err.message
    }
    finally {
      loading.value = false
    }
  }

  async function ReturnOrderId(customerId) {
    try {
      const res = await fetch(`/api/Orders/by-customer/${customerId}`);
      const order = await res.json();
      console.log(order.id);
      return order.id;
    }
    catch (error) {
      console.log("Error fetching order by customer ID", error);
      return null;
    }
  };

  async function progressOrder(id) {
    try {
      const response = await fetch(`/api/Orders/progress-order/${id}`, {
        method: 'PUT'
      });
      if (!response.ok) {
        throw new Error("Failed to update order")
      }
      await getOrders();
    } catch (error) {
      console.log(error)
    }
  }

  async function completeOrder(id) {
    try {
      const response = await fetch(`/api/Orders/complete-order/${id}`, {
        method: 'PUT'
      });
      if (!response.ok) {
        throw new Error("Failed to update order")
      }
      await getOrders();
    } catch (error) {
      console.log(error)
    }
  }

  async function collectOrder(id) {
    try {
      const response = await fetch(`/api/Orders/collect-order/${id}`, {
        method: 'PUT'
      });
      if (!response.ok) {
        throw new Error("Failed to update order")
      }
      await getOrders();
    } catch (error) {
      console.log(error)
    }
  }

  const FilteredOrdersRecieved = computed(() => {
    return orders.value
      .filter(o =>
        o.orderReceived !== null &&
        o.orderInProgress == null &&
        o.orderCompleted == null &&
        o.orderCollected == null
      )
      .sort((a, b) => new Date(a.orderReceived) - new Date(b.orderReceived));
  });

  const FilteredOrdersInProgress = computed(() => {
    return orders.value
      .filter(o =>
        o.orderInProgress !== null &&
        o.orderCompleted == null &&
        o.orderCollected == null
      )
      .sort((a, b) => new Date(a.orderInProgress) - new Date(b.orderInProgress));
  });

  const FilteredOrdersCompleted = computed(() => {
    return orders.value
      .filter(o =>
        o.orderCompleted !== null &&
        o.orderCollected == null
      )
      .sort((a, b) => new Date(a.orderCompleted) - new Date(b.orderCompleted));
  });

  const FilteredOrdersCollected = computed(() => {
    return orders.value
      .filter(o =>
        o.orderCollected !== null
      )
      .sort((a, b) => new Date(a.orderCollected) - new Date(b.orderCollected));
  });

  const ShowOrders = computed(() => {
    return !loading.value && !error.value
  });

  return {
    orders, getOrders,
    loading, error,
    FilteredOrdersRecieved, FilteredOrdersInProgress,
    FilteredOrdersCompleted, FilteredOrdersCollected,
    ShowOrders, progressOrder, completeOrder, collectOrder,
    ReturnOrderId
  }
})

