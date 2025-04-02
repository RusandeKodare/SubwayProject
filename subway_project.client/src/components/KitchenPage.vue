<script>
  import MealOrders from "@/components/QueueComponents/MealOrders.vue";

  export default {
    name: "KitchenPage",
    components: {
      MealOrders,
    },
    data() {
      return {
        listOneTitle: 'Incomming Orders',  // Title for the first list
        listTwoTitle: 'Orders Being Cooked', // Title for the second list
        listOneItems: ['Apple', 'Banana', 'Orange'],  // Items for the first list
        listTwoItems: ['Carrot', 'Broccoli', 'Spinach']  // Items for the second list
      };
    }
  };
</script>

<template>
  <div class="kitchenpage">
    <div class="header-div">

    </div>
    <div class="main-content">
      <div class="left-div">
        <MealOrders :list-title="listOneTitle" :list-items="listOneItems"></MealOrders>
      </div>
      <div class="right-div">
        <MealOrders :list-title="listTwoTitle" :list-items="listTwoItems"></MealOrders>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
