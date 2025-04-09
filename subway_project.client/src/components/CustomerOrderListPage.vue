<script>import MealOrders from "@/components/QueueComponents/MealOrders.vue";

export default {
  name: "CustomerOrderListPage",
  components: {
    MealOrders,
  },
  data() {
    return {
      listOneTitle: "Incomming Orders", // Title for the first list
      listTwoTitle: "Orders Being Cooked", // Title for the second list
      listThreeTitle: "Orders Ready for Pickup", // Title for the third list
      listOneItems: ["Apple", "Banana", "Orange"], // Items for the first list
      listTwoItems: ["Carrot", "Broccoli", "Spinach"], // Items for the second list
      listThreeItems: ["Chicken", "Beef", "Fish"], // Items for the third list
    };
  },
};</script>

<template>
  <div class="kitchenpage">
    <div class="header-div"></div>
    <div class="main-content">
      <div class="left-div">
        <MealOrders :list-title="listOneTitle" :list-items="listOneItems"></MealOrders>
      </div>
      <div class="middle-div">
        <MealOrders :list-title="listTwoTitle" :list-items="listTwoItems"></MealOrders>
      </div>
      <div class="right-div">
        <MealOrders :list-title="listThreeTitle" :list-items="listThreeItems"></MealOrders>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .kitchenpage {
    display: flex;
  }
</style>
