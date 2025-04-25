<script setup>
  import "../assets/main.css";
  import { onBeforeUnmount, onMounted, ref } from "vue";
  import { useRouter, useRoute } from "vue-router";
  import TopNav from "@/components/TopNav.vue";
  import { useOrderStore } from "@/stores/useOrderStore";
  import {useOrdersStore} from "@/stores/OrdersStore";

  const orderStore = useOrderStore();
  const fetchOrders = useOrdersStore();
  const orderNumber = ref(0);

//   const fetchOrderNumber = (customerId) => {
//     console.log(orderStore.order);
//     console.log(customerId);
//   fetch(`/api/orders/by-customer/${customerId}`)
//     .then(response => response.json())
//     .then(order => {
//       if (order) {
//         console.log('Order found:', order);
//         orderNumber = order.id;
//       } else {
//         console.log('Order not found');
//       }
//     })
//     .catch(error => {
//       console.error('Error fetching order:', error);
//     });
// };


  const router = useRouter();
  const route = useRoute();

  const timeoutSeconds = Number(route.query.timeout) || 30;
  const secondsLeft = ref(timeoutSeconds);
  const timeoutInMilliseconds = timeoutSeconds * 1000;
  let redirectTimer = null;
  let countdownTimer = null;

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
  };

  const orderProductsSub = groupedList(orderStore.order.products.filter(prod => prod.subCategoryId >= 1 && prod.subCategoryId <= 5));
  const orderProductsDrinks = groupedList(orderStore.order.products.filter(prod => prod.subCategoryId >= 6 && prod.subCategoryId <= 7));
  const orderProductsSnacks = groupedList(orderStore.order.products.filter(prod => prod.subCategoryId >= 8 && prod.subCategoryId <= 9));
  const orderProductsDesserts = groupedList(orderStore.order.products.filter(prod => prod.subCategoryId >= 10 && prod.subCategoryId <= 11));

  const startNewOrder = () => {
    orderStore.resetOrder();
    clearTimeout(redirectTimer);
    clearInterval(countdownTimer);
    router.push("/");
  }

  let isPaused = false;
  const pauseButtonMessage = ref("Pause timeout");

  const customInterval = () => {
    if (!isPaused && secondsLeft.value > 0) {
      secondsLeft.value--;
      countdownTimer = setTimeout(customInterval, 1000);
    }
    else if (!isPaused && secondsLeft.value === 0) {
      startNewOrder();
    }
  };

  const startTimer = () => {
    isPaused = false;
    customInterval();
  };

  const pauseTimer = () => {
    clearTimeout(countdownTimer);
    isPaused = true;
  };

  const resumeTimer = () => {
    startTimer();
  };

  const handleTimerPause = () => {
    if (isPaused) {
      resumeTimer();
      pauseButtonMessage.value = "Pause timeout";
    } else {
      pauseTimer();
      pauseButtonMessage.value = "Resume timeout";
    }
  };

  onMounted(async () => {
    startTimer();
    orderNumber.value = await fetchOrders.ReturnOrderId(orderStore.order.customerId);
    console.log('order number: ' , orderNumber.value);
  });

  onBeforeUnmount(() => {
    clearTimeout(countdownTimer);
  });

</script>

<template>
  <div class="kitchen-queue-page-container">
    <nav>
      <TopNav />
    </nav>
    <div class="order-container">
      <div class="order-header">
        <p>Your order</p>
        <span>Order number: {{ orderNumber }}</span>
      </div>
      <div v-if="orderProductsSub.length !== 0">
        <p class="order-item-heading">Sub:</p>
        <ul>
          <li v-for="product in orderProductsSub" :key="product.id" :id="`product-` + product.id">{{ product.name }} — {{ product.quantity }} x {{ product.price }}kr</li>
        </ul>
      </div>
      <div v-if="orderProductsDrinks.length !== 0">
        <p class="order-item-heading">Drinks:</p>
        <ul>
          <li v-for="product in orderProductsDrinks" :key="product.id" :id="`product-` + product.id">{{ product.name }} — {{ product.quantity }} x {{ product.price }}kr</li>
        </ul>
      </div>
      <div v-if="orderProductsSnacks.length !== 0">
        <p class="order-item-heading">Snacks:</p>
        <ul>
          <li v-for="product in orderProductsSnacks" :key="product.id" :id="`product-` + product.id">{{ product.name }} — {{ product.quantity }} x {{ product.price }}kr</li>
        </ul>
      </div>
      <div v-if="orderProductsDesserts.length !== 0">
        <p class="order-item-heading">Dessert:</p>
        <ul>
          <li v-for="product in orderProductsDesserts" :key="product.id" :id="`product-` + product.id">{{ product.name }} — {{ product.quantity }} x {{ product.price }}kr</li>
        </ul>
      </div>
      <div class="order-footer">
        <p>Total: {{ orderStore.order.totalPrice }}kr</p>
        <span>Thank you for your order!</span>
      </div>
    </div>
    <p class="redirect-msg">You will be redirected in {{ secondsLeft }} seconds.</p>
    <div class="btn-container">
      <button class="btn pause-btn" @click="handleTimerPause">{{ pauseButtonMessage }}</button>
    </div>
    <div class="btn-container">
      <button class="btn eat-here" @click="startNewOrder">Start new order</button>
    </div>
  </div>
</template>
<style scoped>
  nav {
    height: 11vh;
  }
  .order-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    justify-self: safe center;
    width: 90%;
    max-width: 500px;
    padding: 0 30px 30px 30px;
    margin: 20px 0;
    background-color: #f9f9f9;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  }
    .order-container ul {
      list-style-type: none;
      list-style-position: inside;
    }
    .order-container li {
      margin-left: 20px;
    }
    .order-container span {
      font-size: 1.2rem;
      font-weight: 500;
      text-align: center;
    }
  .order-header {
    font-size: 2rem;
    font-weight: bold;
    text-align: center;
  }
    .order-header span {
      font-size: 1.2rem;
      font-weight: 500;
      text-align: center;
    }
  .order-item {
    margin-left: 20px;
  }
  .order-item-heading {
    font-size: 1.2rem;
    font-weight: 500;
    text-align: left;
  }
  .order-footer {
    font-size: 2rem;
    font-weight: bold;
    text-align: center;
  }
    .order-footer span {
      font-size: 1.2rem;
      font-weight: 500;
      text-align: center;
    }
  .redirect-msg {
    font-size: 1.2rem;
    font-weight: 500;
    text-align: center;
    margin-top: 50px;
  }
    .btn-container {
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 40px;
    height: 20vh;
  }
  .btn {
    padding: 30px 40px;
    border: none;
    border-radius: 20px;
    font-size: 32px;
    font-weight: bold;
    line-height: 1.2;
    cursor: pointer;
    text-align: center;
    font-family: 'Arial Rounded MT Bold', 'Helvetica Rounded', Arial, sans-serif;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
    transition: transform 0.2s ease;
  }
    .btn:hover {
      transform: scale(1.05);
    }
  .eat-here {
    background-color: #F4C12C;
    color: #015643;
  }
  .to-go {
    background-color: #015643;
    color: #F4C12C;
  }
  .pause-btn {
    background-color: #015643;
    color: #F4C12C;
  }
</style>
