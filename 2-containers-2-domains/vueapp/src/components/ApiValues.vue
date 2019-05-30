<template>
  <div>
    <h1>API Values</h1>
    <p>
      Hello from
      <span v-for="val in values" :key="val">
        {{ val }}
      </span>
    </p>
    <p style="color: red">{{ exception }}</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      values: [],
      exception: ''
    }
  },
  created: async function () {
    this.exception = '';
    try {
      const response = await fetch(`${process.env.VUE_APP_BASE_URL}/api/values`);
      let data = await response.json();
      this.values = data;
    } catch (err) {
      console.log('error', err);
      this.exception = 'Exception calling backend. See console for details.';
    }
  }
};
</script>

<style scoped>
</style>
