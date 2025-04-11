<script>
import MealOrders from "@/components/QueueComponents/MealOrders.vue";

export default {
  name: "KitchenPage",
  components: {
    MealOrders,
  },
  data() {
    return {
      listOneTitle: "Incomming Orders", // Title for the first list
      listTwoTitle: "Orders Being Cooked", // Title for the second list
      listOneItems: ["Apple", "Banana", "Orange"], // Items for the first list
      listTwoItems: ["Carrot", "Broccoli", "Spinach"], // Items for the second list
    };
  },
};
</script>

<template>
  <div class="kitchenpage">
    <div class="header-div"></div>
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
  .kitchenpage {

  }
  .header-div {
    width: 100%;
    height: 50px;
    color: white;
    text-align: center;
    line-height: 50px;
  }
  .main-content {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    width: 100%;
    height: 100vh;
    overflow: hidden;
  }
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
