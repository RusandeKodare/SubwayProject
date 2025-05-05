<script setup>
import "../assets/main.css";
import { onBeforeUnmount, onMounted, ref, computed } from "vue";
import { useRouter, useRoute } from "vue-router";
import TopNav from "@/components/TopNav.vue";
import { useOrderStore } from "@/stores/useOrderStore";
import { useOrdersStore } from "@/stores/OrdersStore";
import { useSubStore } from "@/stores/SubStore";

const orderStore = useOrderStore();
const fetchOrders = useOrdersStore();
const orderNumber = ref(0);

const subStore = useSubStore();
const router = useRouter();
const route = useRoute();

const today = new Date().toLocaleDateString('se-SV', {
  year: 'numeric',
  month: '2-digit',
  day: '2-digit',
  hour: '2-digit',
  minute: '2-digit',
});
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

const groupedSubList = computed(() => {
  return orderStore.order.subs.map(sub => {
    const map = {};

    for (const product of sub.products) {
      if (!map[product.name]) {
        map[product.name] = { ...product, quantity: 1 };
      } else {
        map[product.name].quantity += 1;
      }
    }

    return {
      ...sub,
      products: Object.values(map)
    };
  });
});

//const orderProductsSub = groupedList(orderStore.order.products.filter(prod => prod.categoryId === 2));
const orderProductsDrinks = groupedList(orderStore.order.products.filter(prod => prod.categoryId === 3));
const orderProductsSnacks = groupedList(orderStore.order.products.filter(prod => prod.categoryId === 4));
const orderProductsDesserts = groupedList(orderStore.order.products.filter(prod => prod.categoryId === 5));

const startNewOrder = () => {
  orderStore.resetOrder();
  subStore.resetSub(false);
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
  console.log('order number: ', orderNumber.value);
});

onBeforeUnmount(() => {
  clearTimeout(countdownTimer);
});

</script>

<template>

  <nav>
    <TopNav />
  </nav>
  <div class="receipt-container">
    <section class="queue-nr-container">
      <p class=" label-bold">Thank you for your order!</p>
      <span class=" label-bold">Order number: {{ orderNumber }}</span>
      <p>{{ orderStore.order.takeAway ? 'Take Away' : 'Eat Here' }}</p>
      <p>{{ today }}</p>
    </section>

    <section class="section-divider text-center">
      <img class="company-logo" src="../assets/images/SubwayLogo.png" alt="Subway Logo" />

      <div class="company-details">
        <p class="text-left">Biohalm AB<br>Trekanstvägen 1<br>117 43<br>Stockholm<br>559687-0000</p>
        <p class="text-right"></p>
      </div>
    </section>

    <section class="receipt-grid">
      <span class="label-bold">Vara</span>
      <span class="label-bold text-center">Pris</span>
      <span class="label-bold text-right">Kvant</span>
    </section>

    <section class="receipt-section section-divider">
      <ul>
        <div v-if="orderStore.order.subs.length !== 0">
          <p class="order-item-heading"><strong>Subs:</strong></p>
          <div v-for="(sub, index) in groupedSubList" :key="index">
            <p><u>Sub {{ index + 1 }}</u></p>
            <ul>
              <li v-for="product in sub.products" :key="product.id">
                <div class="receipt-grid">
                  <span>{{ product.name }} </span>
                  <span class="text-center">{{ product.price }} kr</span>
                  <span class="text-right">{{ product.quantity }}</span>
                </div>
              </li>
            </ul>
          </div>
        </div>

        <div v-if="orderProductsDrinks.length !== 0">
          <p class="order-item-heading"><strong>Drinks:</strong></p>
          <ul>
            <li v-for="product in orderProductsDrinks" :key="product.id" :id="`product-` + product.id">
              <div class="receipt-grid">
                <span>{{ product.name }} </span>
                <span class="text-center">{{ product.price }} kr</span>
                <span class="text-right">{{ product.quantity }}</span>
              </div>
            </li>
          </ul>
        </div>
        <div v-if="orderProductsSnacks.length !== 0">
          <p class="order-item-heading"><strong>Snacks:</strong></p>
          <ul>
            <li v-for="product in orderProductsSnacks" :key="product.id" :id="`product-` + product.id">
              <div class="receipt-grid">
                <span>{{ product.name }} </span>
                <span class="text-center">{{ product.price }} kr</span>
                <span class="text-right">{{ product.quantity }}</span>
              </div>
            </li>
          </ul>
        </div>
        <div v-if="orderProductsDesserts.length !== 0">
          <p class="order-item-heading"><strong>Dessert:</strong></p>
          <ul>
            <li v-for="product in orderProductsDesserts" :key="product.id" :id="`product-` + product.id">
              <div class="receipt-grid">
                <span>{{ product.name }} </span>
                <span class="text-center">{{ product.price }} kr</span>
                <span class="text-right">{{ product.quantity }}</span>
              </div>
            </li>
          </ul>
        </div>
      </ul>
    </section>

    <section class="total-price-container">
      <div>
        <p class="total-price">Totalt</p>
      </div>

      <div>
        <p class="total-price"> {{ orderStore.order.totalPrice }} kr </p><br>
      </div>
    </section>
    <div class="order-footer">
      <div class="vat-container">
        <span class="text-left">VAT%</span>
        <span class="text-center">Total</span>
        <span class="text-center">VAT</span>
        <span class="text-right">Subtotal(Net)</span>
        <p class="text-left">12,0%</p>
        <p class="text-center">{{ (orderStore.order.totalPrice).toFixed(2) }}</p>
        <p class="text-center">{{ (orderStore.order.totalPrice * 0.12).toFixed(2) }} </p>
        <p class="text-right">{{ (orderStore.order.totalPrice * 0.88).toFixed(2) }} </p>
      </div>
      <span>We hope to see you again!</span>
    </div>
  </div>

  <p class="redirect-msg">You will be redirected in {{ secondsLeft }} seconds.</p>
  <div class="btn-container">
    <button class="btn pause-btn" onclick="alert('The receipt printer is currently out of paper.')">Print
      receipt</button>
    <button class="btn pause-btn" @click="handleTimerPause">{{ pauseButtonMessage }}</button>
  </div>
  <div class="btn-container">
    <button class="btn eat-here" @click="startNewOrder">Start new order</button>
  </div>
</template>

<style scoped>
nav {
  height: 11vh;
}

.receipt-container ul {
  list-style: none;
}

.receipt-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 70%;
  min-width: 270px;
  max-width: 350px;
  margin: 0 auto;
  margin-top: 5rem;
  margin-bottom: 5rem;
  height: 100%;
  border: 1px solid black;
  padding: 1rem;
}

.receipt-container .receipt-section {
  width: 100%;
}

.receipt-container .queue-nr-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  border-bottom: 5px dotted;
  margin-bottom: 1rem;
  padding-bottom: 0.7rem;
  width: 100%;
  font-size: 20px;
}

.receipt-container .queue-number {
  font-size: 5rem;
}

.receipt-container .company-logo {
  width: 35%;
}

.receipt-container .date-receipt-nr {
  display: flex;
  justify-content: space-between;
  width: 100%;
}

.receipt-container .company-details {
  display: flex;
  justify-content: space-between;
  width: 100%;
}

.receipt-container .receipt-grid {
  display: grid;
  grid-template-columns: 2fr 1fr 1fr;
  width: 100%;
}

.receipt-container .label-bold {
  margin-bottom: 10px;
  font-weight: bold;
}

.receipt-container .text-center {
  text-align: center;
}

.receipt-container .text-right {
  text-align: right;
}

.receipt-container .text-left {
  text-align: left;
}

.receipt-ingredient {
  padding-left: 0.7rem;
  font-size: 0.8rem;
}

.receipt-container .total-price-container {
  display: flex;
  justify-content: space-between;
  width: 100%;
}

.receipt-container .total-price {
  font-size: 20px;
  font-weight: bold;
}

.receipt-container .vat-amount {
  display: flex;
  justify-content: flex-end;
}

.receipt-container .section-divider {
  border-bottom: 3px dotted;
  margin-bottom: 0.7rem;
  padding-bottom: 0.7rem;
}

.reset-btn {
  position: fixed;
  top: 95%;
  left: 10%;
  transform: translate(-50%, -50%);
  padding: 0.5rem;
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

.vat-container {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  font-size: 1rem;
  font-weight: normal;
}

.vat {
  margin-right: 2rem;
  font-size: 0, 5rem;
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
</style>
